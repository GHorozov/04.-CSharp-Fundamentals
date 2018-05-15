using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            //take path of all files in directory
            var filePath = Directory.GetFiles(@"../../", "*.*", SearchOption.AllDirectories);
            List<FileInfo> files = filePath.Select(path => new FileInfo(path)).ToList();

            //sort all files
            var sorted = files.OrderBy(file => file.Length).GroupBy(file => file.Extension).OrderByDescending(group => group.Count()).ThenBy(group => group.Key);

            //find desktop
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (var writer = new StreamWriter(desktop + "/report.txt"))
            {
                foreach (var group in sorted)
                {
                    writer.WriteLine(group.Key);

                    foreach (var item in group)
                    {
                        writer.WriteLine($"--{item.Name} - {item.Length / 1024:f3}kb");
                    }
                }
            }
        }
    }
}
