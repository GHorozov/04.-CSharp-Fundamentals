namespace P05.Logger
{
    using System;
    using P05.Logger.Models;
    using P05.Logger.Models.Interfaces;
    using System.Collections.Generic;
    using P05.Logger.Models.Factories;

    public class StartUp
    {
        static void Main(string[] args)
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();
            var engine = new Engine(logger, errorFactory);
            engine.Run();
        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            var appendersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appendersCount; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var appenderType = input[0];
                var layoutType = input[1];
                string errorLevel = "INFO";
                if (input.Length == 3)
                {
                    errorLevel = input[2];
                }

                IAppender newAppender = appenderFactory.GetAppender(appenderType, errorLevel, layoutType);
                appenders.Add(newAppender);
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }
    }
}
