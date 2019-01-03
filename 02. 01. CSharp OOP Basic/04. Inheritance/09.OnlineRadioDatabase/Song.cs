using System;

public class Song
{
    private string artist;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artist, string songName, int minutes, int seconds)
    {
        this.Artist = artist;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    protected string Artist
    {
        get { return artist; }
        set
        {
            if(value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException("Artist name should be between 3 and 20 symbols.");
            }
            artist = value;
        }
    }

    protected string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < 3 || value.Length >30)
            {
                throw new InvalidSongNameException("Song name should be between 3 and 30 symbols.");
            }
            songName = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        protected set
        {
            if(value <0 || value > 14)
            {
                throw new InvalidSongMinutesException("Song minutes should be between 0 and 14.");
            }
            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        protected set
        {
            if(value< 0 || value > 59)
            {
                throw new InvalidSongSecondsException("Song seconds should be between 0 and 59."); 
            }
            seconds = value;
        }
    }
}