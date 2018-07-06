namespace _05._Slicing_File
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class SlicingFile
    {
        static void Main(string[] args)
        {
            var parts = 5;
            var sourcePath = "sliceMe.mp4";
            var destinationPartsPath = "../../../FileParts/";
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPartsPath));
            List<string> files = new List<string>();

            Slice(sourcePath, destinationPartsPath, parts, files);

            var assembleFilesPath = "../../../AssembleResult/";
            Directory.CreateDirectory(Path.GetDirectoryName(assembleFilesPath));
            Assemble(files, assembleFilesPath, sourcePath);
        }

        private static void Assemble(List<string> files, string assembleFilesPath, string sourcePath)
        {
            using (FileStream streamWrite = new FileStream(assembleFilesPath + Path.GetFileName(sourcePath), FileMode.Create))
            {
                foreach (var file in files)
                {
                    using (FileStream streamRead = new FileStream(file, FileMode.Open))
                    {
                        var buffer = new byte[4096];
                        while (true)
                        {
                            var readBytes = streamRead.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) break;
                            streamWrite.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        private static void Slice(string sourceFile, string destinationPartsPath, int parts, List<string> files)
        {
            using (FileStream fsRead = new FileStream(sourceFile, FileMode.Open))
            {
                var partSize = (fsRead.Length / parts) + fsRead.Length % parts;
                byte[] buffer = new byte[partSize];
                var number = 1;
                while (true)
                {
                    var readByte = fsRead.Read(buffer, 0, buffer.Length);
                    if (readByte == 0) break;
                    using (FileStream fsWrite = new FileStream(destinationPartsPath + $"part{number++}" + Path.GetExtension(sourceFile), FileMode.Create))
                    {
                        files.Add(destinationPartsPath + $"part{number - 1}" + Path.GetExtension(sourceFile));
                        fsWrite.Write(buffer, 0, buffer.Length);
                    }
                }       
            }
        }


    }
}
