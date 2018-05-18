using _06.Logger.Entities;
using _06.Logger.Entities.Apenders;
using _06.Logger.Interfaces;
using _06.Logger.Layouts;
using _06.LoggerTask.Entities;
using _06.LoggerTask.Entities.Apenders;
using _06.LoggerTask.Entities.Layouts;
using _06.LoggerTask.Enums;
using _06.LoggerTask.Factory;
using System;
using System.Globalization;
using System.Reflection;

namespace LoggerTask
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //I-part
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            //ILogger logger = new Logger(consoleAppender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");


            //II-part
            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);

            //var file = new LogFile();
            //var fileAppender = new FileAppender(simpleLayout);
            //fileAppender.File = file;

            //var logger = new Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");


            //III-part
            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);
            //var logger = new Logger(consoleAppender);

            //logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            //logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");



            //IV-part
            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = ReportLevel.Error;

            //var logger = new Logger(consoleAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warn("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");


            //V-part
            var appendersCount = int.Parse(Console.ReadLine());
            IAppender[] appenders = new IAppender[appendersCount];
            for (int i = 0; i < appendersCount; i++)
            {
                var appenderInfo = Console.ReadLine().Split(' ');
                ILayout currentLayout = LayoutFactory.GetInstance(appenderInfo[1]);
                IAppender currentAppender = AppenderFactory.GetAppender(appenderInfo[0], currentLayout);

                if (appenderInfo.Length > 2)
                {
                    string enumName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(appenderInfo[2].ToLower());
                    currentAppender.ReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), enumName);
                }

                appenders[i] = currentAppender;
            }

            Logger myLogger = new Logger(appenders);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split('|');

                var methodName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tokens[0].ToLower());

                MethodInfo currentMethod = typeof(Logger).GetMethod(methodName);

                currentMethod.Invoke(myLogger, new object[] { tokens[1], tokens[2] });
            }

            Console.WriteLine(myLogger);
        }
    }
}
