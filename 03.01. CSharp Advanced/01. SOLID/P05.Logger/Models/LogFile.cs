namespace P05.Logger.Models
{
    using System;
    using System.IO;
    using P05.Logger.Models.Interfaces;

    public class LogFile : ILogFile
    {
        private const string DefaultPath = "./data/";

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            InitializeFile();
            this.Size = 0;
        }

        public string Path { get; }
        public int Size { get; private set; }

        private void InitializeFile()
        {
            Directory.CreateDirectory(DefaultPath);
            File.AppendAllText(this.Path, "");
        }

        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            var totalSize = 0;
            for (int i = 0; i < errorLog.Length; i++)
            {
                totalSize += errorLog[i];
            }

            this.Size += totalSize;
        }
    }
}
