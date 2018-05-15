using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StartUp
{
    static void Main(string[] args)
    {
        var numberOfSongs = int.Parse(Console.ReadLine());
        var playlist = new List<Song>();

        for (int i = 0; i < numberOfSongs; i++)
        {
            var linePart = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (linePart.Length < 3)
                {
                    throw new ArgumentException("Invalid song.");
                }

                var group = linePart[0];
                var song = linePart[1];
                var songLength = linePart[2].Split(':');
                var minutes = int.Parse(songLength[0]);
                var seconds = int.Parse(songLength[1]);

                var currentSong = new Song(group, song, minutes, seconds);
                Console.WriteLine("Song added.");

                playlist.Add(currentSong);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException fex)
            {
                Console.WriteLine("Invalid song length.");
            }
        }

        Console.WriteLine($"Songs added: {playlist.Count}");

        var totalSeconds = playlist.Select(s => s.Seconds).Sum();
        var secondsToMinutes = totalSeconds / 60;
        var secondsResult = totalSeconds % 60;

        var totalMinutes = playlist.Select(m => m.Minutes).Sum()+secondsToMinutes;
        var munutesToHours = totalMinutes / 60;
        var minutesResult = totalMinutes % 60;

        var hoursResult = munutesToHours;
        Console.WriteLine($"Playlist length: {hoursResult}h {minutesResult}m {secondsResult}s");
    }
}

