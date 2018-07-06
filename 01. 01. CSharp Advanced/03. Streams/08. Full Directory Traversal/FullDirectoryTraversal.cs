namespace _08._Full_Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class FullDirectoryTraversal
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path:");
            var path = Console.ReadLine();
            List<FileInfo> files = new List<FileInfo>();

            GetAllFilesInDirectory(path, files);

            ReportFiles(files);

        }

        private static void ReportFiles(List<FileInfo> files)
        {
            var sortedFiles = files
               .OrderBy(x => x.Length)
               .GroupBy(x => x.Extension)
               .OrderByDescending(x => x.Count())
               .ThenBy(x => x.Key)
               .ToArray();

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

        private static void GetAllFilesInDirectory(string path, List<FileInfo> files)
        {
            files.AddRange(Directory.GetFiles(path).Select(x => new FileInfo(x)));

            foreach (var dir in Directory.GetDirectories(path))
            {
                GetAllFilesInDirectory(dir, files);
            }
        }
    }
}
