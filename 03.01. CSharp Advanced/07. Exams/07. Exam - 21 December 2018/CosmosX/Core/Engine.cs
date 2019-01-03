using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;
using System;
using System.Linq;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = true;
        }

        public void Run()
        {
            while (isRunning)
            {
                var args = this.reader.ReadLine().Split(new [] { " " }, System.StringSplitOptions.RemoveEmptyEntries).ToList();

                var result = string.Empty;
                try
                {
                     result = this.commandParser.Parse(args);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }

                if(args[0] == "Exit")
                {
                    isRunning = false;
                }

                this.writer.WriteLine(result);
            }
        }
    }
}