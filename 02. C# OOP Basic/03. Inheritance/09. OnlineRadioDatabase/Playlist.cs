using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Song
{
    private string artist;
    private string songName;
    private int minutes;
    private int seconds;


    public Song(string artist, string song, int minutes, int seconds)
    {
        this.Artist = artist;
        this.SongName = song;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public string Artist
    {
        get
        {
            return this.artist;
        }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }

            this.artist = value;
        }
    }

    public string SongName
    {
        get
        {
            return this.songName;
        }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }

            this.songName = value;
        }
    }

    public int Minutes
    {
        get
        {
            return this.minutes;
        }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }

            this.minutes = value;
        }
    }

    public int Seconds
    {
        get
        {
            return this.seconds;
        }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }

            this.seconds = value;
        }
    }

}


