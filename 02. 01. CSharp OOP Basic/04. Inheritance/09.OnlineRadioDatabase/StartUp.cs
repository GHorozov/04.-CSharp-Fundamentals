namespace _09.OnlineRadioDatabase
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var radio = new RadioStation();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (input.Length != 3)
                    {
                        throw new InvalidSongException("Invalid song.");
                    }
                   
                    var artist = input[0];
                    var songName = input[1];
                    var time = input[2].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    var minutes = int.Parse(time[0]);
                    var seconds = int.Parse(time[1]);

                    var newSong = new Song(artist, songName, minutes, seconds);
                    radio.AddSong(newSong);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException fex)
                {
                    Console.WriteLine("Invalid song length.");
                }
            }

            Console.WriteLine(radio);
        }
    }
}
