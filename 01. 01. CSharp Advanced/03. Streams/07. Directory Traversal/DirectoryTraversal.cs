namespace _07._Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            var filePath = Directory.GetFiles(@"../../", "*.*", SearchOption.TopDirectoryOnly);
            List<FileInfo> listFiles = filePath.Select(x => new FileInfo(x)).ToList();

            var sortedFiles = listFiles
                .OrderBy(x => x.Length)
                .GroupBy(x => x.Extension)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key);

            var destination = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter result = new StreamWriter(destination + "/report.txt"))
            {
                foreach (var group in sortedFiles)
                {
                    result.WriteLine(group.Key);

                    foreach (var item in group)
                    {
                        result.WriteLine($"--{item.Name} - {item.Length / 1024:f3}kb");
                    }
                }
            }
                

        }
    }
}
