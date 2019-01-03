namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;

	/// <summary>
	/// by g0shk0
	/// </summary>
	public class Engine : IEngine
	{
	    private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

		// дайгаз
		public void Run()
		{
			while (true) // for job security
			{
				var input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

				try
				{
                    var result = ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex) // in case we run out of memory
				{
					this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
				}
			}

			var endReport = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(endReport);
		}

		public string ProcessCommand(string input)
		{
			var lineParts = input.Split(" ");
			var command = lineParts.First();
			var args = lineParts.Skip(1).ToArray();

			if (command == "LetsRock")
			{
				var sets = this.setCоntroller.PerformSets();
				return sets;
			}

			var methodToExecute = this.festivalCоntroller
                .GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == command);

			string result;

			//try
			//{
                result = (string)methodToExecute.Invoke(this.festivalCоntroller, new object[] { args });
			//}
			//catch (Exception ex)
			//{
   //             result = ex.InnerException.Message;
			//}

			return result;
		}
    }
}