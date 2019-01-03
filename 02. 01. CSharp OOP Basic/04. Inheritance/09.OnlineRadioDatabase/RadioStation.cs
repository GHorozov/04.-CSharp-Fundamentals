using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RadioStation
{
    private List<Song> songs;

    public RadioStation()
    {
        this.songs = new List<Song>();
    }

    public void AddSong(Song song)
    {
        songs.Add(song);
    }

    private string GetPlaylistTime()
    {
        var allminutes = songs.Select(x => x.Minutes).Sum();
        var allSeconds = songs.Select(x => x.Seconds).Sum();
        var minutesToSeconds = allminutes * 60;
        var allTimeInSeconds = minutesToSeconds + allSeconds;
        var time = TimeSpan.FromSeconds(allTimeInSeconds);

        return $"{time.Hours}h {time.Minutes}m {time.Seconds}s";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Songs added: {songs.Count}");
        sb.AppendLine($"Playlist length: {GetPlaylistTime()}");

        return sb.ToString().TrimEnd(); 
    }
}
