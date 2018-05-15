using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            var filePath = Console.ReadLine(); // ../../image.jpg

            using (var reader = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var write= new FileStream("result.jpg", FileMode.Create))
                {
                    var buffer = new byte[4096];
                    int readImage = reader.Read(buffer, 0, buffer.Length); ;
                    while(true)
                    {
                        write.Write(buffer, 0, readImage);
                        if(readImage == 0)
                        {
                            break;
                        }
                        readImage = reader.Read(buffer, 0, buffer.Length);
                    }
                   
                }       
            }
        }
    }
}
