namespace FestivalManager.Entities.Factories
{
	using System;
	using Contracts;
	using Entities.Contracts;

	public class SongFactory : ISongFactory
	{
		public ISong CreateSong(string name, TimeSpan duration)
		{
            var type = typeof(Song);
			var song = (ISong)Activator.CreateInstance(type, new object[] { name, duration });

            return song;
        }
	}
}