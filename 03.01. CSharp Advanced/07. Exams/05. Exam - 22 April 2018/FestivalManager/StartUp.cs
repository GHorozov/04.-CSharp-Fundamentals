namespace FestivalManager
{
    using System;
	using Core;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Entities;
    using FestivalManager.Core.IO;
    using FestivalManager.Core.IO.Contracts;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
			Stage stage = new Stage();
			ISetController setController = new SetController(stage);
            IFestivalController festivalController = new FestivalController(stage);

            var engine = new Engine(reader, writer, festivalController, setController);
			engine.Run();
		}
	}
}