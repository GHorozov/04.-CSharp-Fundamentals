﻿namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private readonly IStage stage;
        private ISetFactory setFactory;
        private IPerformerFactory performerFactory;
        private IInstrumentFactory instrumentFactory;
        private ISongFactory songFactory;

		public FestivalController(IStage stage)
		{
			this.stage = stage;
            this.setFactory = new SetFactory();
            this.performerFactory = new PerformerFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.songFactory = new SongFactory();
		}

        public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            var totalTime = totalFestivalLength.ToString(TimeFormat);
            if(totalFestivalLength.TotalMinutes >= 60)
            {
                totalTime = $"{totalFestivalLength.TotalMinutes}:00";
            }

            result += ($"Festival length: {totalTime}") + "\n";

			foreach (var set in this.stage.Sets)
			{
                var setTotalTime = set.ActualDuration.ToString(TimeFormat);
                if(set.ActualDuration.TotalMinutes >= 60)
                {
                    setTotalTime = $"{set.ActualDuration.TotalMinutes}:00";
                }

                result += ($"--{set.Name} ({setTotalTime}):") + "\n";

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
            var set = this.setFactory.CreateSet(args[0], args[1]);
            this.stage.AddSet(set);

            return $"Registered {args[1]} set";
		}

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var performerInputInstruments = args.Skip(2).ToArray();

			var allPerformerInstruments = performerInputInstruments
                .Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			var performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in allPerformerInstruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            var name = args[0];
            var duratuion = args[1];
            var timeSpanDuration = TimeSpan.ParseExact(duratuion, TimeFormat, CultureInfo.InvariantCulture);

            var song = this.songFactory.CreateSong(name, timeSpanDuration);
            this.stage.AddSong(song);

			return $"Registered song {name} ({duratuion})";
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

			return $"Added {song.ToString()} to {set.Name}";
		}

		// Временно!!! Чтобы работало делаем срез на конец месяца
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

            var set = this.stage.GetSet(setName);
            var performer = this.stage.GetPerformer(performerName);

            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
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