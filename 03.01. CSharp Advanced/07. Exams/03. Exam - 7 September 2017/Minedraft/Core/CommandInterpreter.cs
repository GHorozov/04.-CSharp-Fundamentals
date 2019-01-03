using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string Suffix = "Command";

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get;  }
    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        var input = args[0] + Suffix;

        var allCommand = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .Where(x => typeof(ICommand).IsAssignableFrom(x) && !x.IsAbstract)
            .ToArray();

        var commandType = allCommand.FirstOrDefault(x => x.Name == input);
        if(commandType == null)
        {
            throw new InvalidOperationException("Invalid command!");
        }

        var command = (ICommand)Activator.CreateInstance(commandType, new object[] { args.Skip(1).ToList(), this.HarvesterController, this.ProviderController });
        var result = command.Execute();

        return result;
    }
}

