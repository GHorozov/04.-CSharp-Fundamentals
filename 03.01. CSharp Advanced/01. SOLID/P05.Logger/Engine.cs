namespace P05.Logger
{
    using System;
    using P05.Logger.Models.Factories;
    using P05.Logger.Models.Interfaces;

    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger,ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var lineParts = input.Split("|");
                var stringErrorLevel = lineParts[0];
                var time = lineParts[1];
                var message = lineParts[2];

                IError error = this.errorFactory.GetError(stringErrorLevel, time, message);
                this.logger.Log(error);
            }

            Console.WriteLine("Logger info:");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
