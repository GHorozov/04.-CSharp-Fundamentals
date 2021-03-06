﻿namespace FestivalManager.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		private readonly List<ISet> sets;
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;

        public IReadOnlyCollection<ISong> Songs => this.songs;

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            var result = this.performers.FirstOrDefault(x => x.Name == name);
            if(result == null)
            {
                throw new ArgumentException("Performer with that name doesnt exist");
            }

            return result; 
        }

        public ISet GetSet(string name)
        {
            var result = this.sets.FirstOrDefault(x => x.Name == name);
            if (result == null)
            {
                throw new ArgumentException("Set with that name doesnt exist");
            }

            return result;
        }

        public ISong GetSong(string name)
        {
            var result = this.songs.FirstOrDefault(x => x.Name == name);
            if (result == null)
            {
                throw new ArgumentException("Song with that name doesnt exist");
            }

            return result;
        }

        public bool HasPerformer(string name)
        {
            return this.performers.Any(x => x.Name == name);
        }

        public bool HasSet(string name)
        {
            return this.sets.Any(x => x.Name == name);
        }

        public bool HasSong(string name)
        {
            return this.songs.Any(x => x.Name == name);
        }
    }
}
