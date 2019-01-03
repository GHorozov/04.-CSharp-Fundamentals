using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            var streamProgressInfo = new StreamProgressInfo(new File("fileName", 100, 1000));
            var streamProgressInfo1 = new StreamProgressInfo(new Music("artist", "album", 100, 26));
        }
    }
}
