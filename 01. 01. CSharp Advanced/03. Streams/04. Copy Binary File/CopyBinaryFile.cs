namespace _04._Copy_Binary_File
{
    using System;
    using System.IO;

    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            using (FileStream streamRead = new FileStream("copyMe.png", FileMode.Open))
            {
                using (FileStream streamCreate = new FileStream("copiedFile.png", FileMode.Create))
                {
                    streamRead.CopyTo(streamCreate);
                }
            }
        }
    }
}
