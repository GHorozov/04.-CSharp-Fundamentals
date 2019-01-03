namespace _04.MovieTime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Movie
    {
        public Movie(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public string Genre { get; set; }
        public string StrTime { get; set; }
        public long TimeInSeconds { get; set; }
    }

    class StartUp
    {
        static void Main(string[] args)
        {
            var movieList = new List<Movie>();
            var favoriteGenre = Console.ReadLine();
            var movieDuration = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "POPCORN!")
            {
                var lineParts = input.Split("|");
                var name = lineParts[0];
                var genre = lineParts[1];
                var timeStr = lineParts[2];
                var duration = lineParts[2].Split(":");
                var hours = int.Parse(duration[0]);
                var minutes = int.Parse(duration[1]);
                var seconds = int.Parse(duration[2]);
                var time = seconds + (hours * 3600) + (minutes * 60);

                var currentMovie = movieList.FirstOrDefault(x => x.Name == name);
                if (currentMovie == null)
                {
                    var newMovie = new Movie(name);
                    newMovie.Genre = genre;
                    newMovie.StrTime = timeStr;
                    newMovie.TimeInSeconds = time;
                    movieList.Add(newMovie);
                }
            }

            if (movieDuration == "Short")
            {
                var orderedMovies = movieList
                    .OrderByDescending(x => x.Genre == favoriteGenre)
                    .ThenBy(x => x.TimeInSeconds)
                    .ThenBy(x => x.Name);

                PrintResult(movieList, orderedMovies);
            }
            else if (movieDuration == "Long")
            {
                var orderedMovies = movieList
                    .OrderByDescending(x => x.Genre == favoriteGenre)
                    .ThenByDescending(x => x.TimeInSeconds)
                    .ThenBy(x => x.Name);

                PrintResult(movieList, orderedMovies);
            }
        }

        private static void PrintResult(List<Movie> movieList, IOrderedEnumerable<Movie> orderedMovies)
        {
            foreach (var movie in orderedMovies)
            {
                var reaction = Console.ReadLine();

                if (reaction == "Yes")
                {
                    Console.WriteLine(movie.Name);
                    Console.WriteLine($"We're watching {movie.Name} - {movie.StrTime}");
                    var totalTime = TakeTotalTime(movieList);

                    Console.WriteLine($"Total Playlist Duration: {totalTime}");
                    break;
                }
                else
                {
                    Console.WriteLine($"{movie.Name}");
                }
            }
        }

        private static string TakeTotalTime(List<Movie> movieList)
        {
            var allSumTime = movieList.Sum(x => x.TimeInSeconds);
            if (allSumTime == 0)
            {
                return "00:00:00";
            }
            if(allSumTime < 60)
            {
                return $"00:00:{allSumTime}";
            }

            var hours = allSumTime / 3600;
            var minutes = allSumTime % 3600 / 60;
            var seconds = 0L;
            if (minutes > 0)
            {
                seconds = allSumTime % 3600 % minutes;
            }

            var time = string.Empty;
            if (hours <= 9)
            {
                time += "0" + hours;
            }
            else
            {
                time += hours;
            }

            time += ":";
            if(minutes <= 9)
            {
                time += "0" + minutes;
            }
            else
            {
                time += minutes;
            }
            time += ":";
            if(seconds <= 9)
            {
                time += "0" + seconds;
            }
            else
            {
                time += seconds;
            }

            return time;
        }
    }
}
