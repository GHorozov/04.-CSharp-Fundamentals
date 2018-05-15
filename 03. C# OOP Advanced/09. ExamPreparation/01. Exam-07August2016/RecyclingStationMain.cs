namespace RecyclingStation
{
    using _01.Exam_07August2016.BusinessLayer.Constracts.Core;
    using _01.Exam_07August2016.BusinessLayer.Constracts.Interfaces;
    using _01.Exam_07August2016.BusinessLayer.Constracts.IO;
    using _01.Exam_07August2016.BusinessLayer.Core;
    using _01.Exam_07August2016.BusinessLayer.Factories;
    using _01.Exam_07August2016.BusinessLayer.IO;
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Collections.Generic;

    public class RecyclingStationMain
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IStrategyHolder stritegyHolder = new StrategyHolder(new Dictionary<Type, IGarbageDisposalStrategy>());
            IGarbageProcessor garbageProcessor = new GarbageProcessor(stritegyHolder);
            IWasteFactory wasteFactory = new WasteFactory();


            IRecyclingManager recyclingManager = new RecyclingManager(garbageProcessor, wasteFactory);

            IEngine engine = new Engine(reader, writer, recyclingManager);
            engine.Run();
        }
    }
}
