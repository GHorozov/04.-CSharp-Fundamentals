using System;
using System.Linq;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public Engine(IReader reader, IWriter writer, IHarvesterController harvesterController, IProviderController providerController)
    {
        this.reader = reader;
        this.writer = writer;
        this.harvesterController = harvesterController;
        this.providerController = providerController;
        this.commandInterpreter = new CommandInterpreter(harvesterController, providerController);
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                var input = this.reader.ReadLine();
                var data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var result = this.commandInterpreter.ProcessCommand(data);
                this.writer.WriteLine(result);

                if (data[0].ToLower() == "shutdown")
                {
                    break;
                }
            }
            catch (Exception ex)
            {
                this.writer.WriteLine(ex.Message);
            }
        }
    }
}
