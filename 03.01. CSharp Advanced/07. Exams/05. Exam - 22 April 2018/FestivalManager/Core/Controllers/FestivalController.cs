namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Linq;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private readonly IStage stage;
        private IInstrumentFactory instrumentFactory;
        private ISetFactory setFactory;

		public FestivalController(IStage stage)
		{
			this.stage = stage;
            this.instrumentFactory = new InstrumentFactory();
            this.setFactory = new SetFactory();
        }

		public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            if(totalFestivalLength.Hours > 1)
            {
                var minutes = totalFestivalLength.Hours * 60 + totalFestivalLength.Minutes;
                result += ($"Festival length: {minutes:00}:{totalFestivalLength.Seconds:00}") + "\n";
            }
            else if (totalFestivalLength.Hours == 1)
            {
                result += ($"Festival length: 60:{totalFestivalLength.Seconds:00}") + "\n";
            }
            else
            {
                result += ($"Festival length: {totalFestivalLength.ToString(TimeFormat)}") + "\n";
            }


            foreach (var set in this.stage.Sets)
            {
                if (set.ActualDuration.Hours > 1)
                {
                    var minutes = set.ActualDuration.Hours * 60 + set.ActualDuration.Minutes; 
                    result += ($"--{set.Name} ({minutes:00}:{set.ActualDuration.Seconds:00}):") + "\n";
                }
                else if (set.ActualDuration.Hours == 1)
                {
                    result += ($"--{set.Name} (60:{set.ActualDuration.Seconds:00}):") + "\n";
                }
                else
                {
                    result += ($"--{set.Name} ({set.ActualDuration.ToString(TimeFormat)}):") + "\n";
                }

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
					}
				}
			}

			return result.ToString().TrimEnd();
		}

		public string RegisterSet(string[] args)
		{
            var setName = args[0];
            var setType = args[1];

            var set = this.setFactory.CreateSet(setName, setType);
            this.stage.AddSet(set);

            return $"Registered {setType} set";
		}

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);
			var instruments = args.Skip(2).ToArray();

			var performer = new Performer(name, age);
			foreach (var instrument in instruments)
			{
                var instrumentResult = this.instrumentFactory.CreateInstrument(instrument);
				performer.AddInstrument(instrumentResult);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            var name = args[0];
            var timeLast = args[1].Split(":");
            var minutes = int.Parse(timeLast[0]);
            var secunds = int.Parse(timeLast[1]);
            var duration = new TimeSpan(0, minutes, secunds);

            var song = new Song(name, duration);
            this.stage.AddSong(song);

			return $"Registered song {name} ({duration:mm\\:ss})"; //song
		}

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration:mm\\:ss}) to {setName}";
        }

        public string AddPerformerToSet(string[] args)
		{
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);
            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }
	
		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
    }
}