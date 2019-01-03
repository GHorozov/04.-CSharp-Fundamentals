namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
	using Contracts;
	using Controllers.Contracts;
	using IO.Contracts;

	public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;
        private IFestivalController festivalController;
        private ISetController setController;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalController,ISetController setController )
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalController = festivalController;
            this.setController = setController;
        }

		public void Run()
		{
			while (true)
			{
				var input = this.reader.ReadLine();

				if (input == "END")
					break;

				try
				{
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex) 
				{
					this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
				}
			}

			var end = this.festivalController.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

        public string ProcessCommand(string input)
        {
            var args = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var command = args[0];
            args = args.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                var result = this.setController.PerformSets();
                return result;
            }

            string methodResult = (string)this.festivalController
                .GetType()
                .GetMethod(command, BindingFlags.Instance | BindingFlags.Public)
                .Invoke(this.festivalController,new object[] { args });

            return methodResult;
        }
    }
}