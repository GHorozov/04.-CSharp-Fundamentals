using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlicingFile
{
    class SlicingFile
    {
        static void Main(string[] args)
        {
            var files = new List<string>();

            Console.WriteLine("Add source path: ");
            var sourcePath = Console.ReadLine(); // ../../text.txt
            var resultPath = "../../result/"; // where result will be stored.
            Directory.CreateDirectory(Path.GetDirectoryName(resultPath)); // create directory for result.

            Console.WriteLine("Add number of parts: ");
            var parts = int.Parse(Console.ReadLine()); //user add number of parts.

            //Slice
            using (var readSource = new FileStream(sourcePath, FileMode.Open))
            {

                var sizeOfSource = readSource.Length;
                var eachPartSize = (readSource.Length / parts) + readSource.Length % parts; //take each part size.

                for (int i = 1; i <= parts; i++)
                {
                    //create name for each new part with number and extension.
                    using (var result = new FileStream(resultPath + Path.GetFileNameWithoutExtension(sourcePath) + "-" + i + ".gz", FileMode.Create))
                    {
                        using (var compressSteam= new GZipStream(result, CompressionMode.Compress, false))
                        {
                            //add each new file part to list files.
                            files.Add(resultPath + Path.GetFileNameWithoutExtension(sourcePath) + "-" + i + ".gz");

                            var num = 0;
                            while (true)
                            {
                                num++;
                                var buffer = new byte[eachPartSize];
                                var readBytes = readSource.Read(buffer, 0, buffer.Length);
                                compressSteam.Write(buffer, 0, readBytes);

                                if (num == 1)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

            }


            //Assembly
            using (var result = new FileStream(resultPath + Path.GetFileName(sourcePath), FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using (var source = new FileStream(files[i], FileMode.Open))
                    {
                        using (var decompressStream= new GZipStream(source, CompressionMode.Decompress, false))  
                        {
                            var buffer = new byte[4096];
                            while (true)
                            {
                                var readBytes = decompressStream.Read(buffer, 0, buffer.Length); // read compress files.
                                if (readBytes == 0) break;

                                result.Write(buffer, 0, readBytes); // Writes assembly file to result directory.
                            }

                        }
                    }
                }
            }


        }
    }
}
