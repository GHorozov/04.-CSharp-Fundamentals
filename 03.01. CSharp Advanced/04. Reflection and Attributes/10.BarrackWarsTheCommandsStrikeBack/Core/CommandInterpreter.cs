using System;
using System.Linq;
using System.Reflection;

internal class CommandInterpreter : ICommandInterpreter
{
    private const string SuffixCommand = "UnitCommand";

    private IRepository repository;
    private IUnitFactory unitFactory;

    public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        var inputCommandName = commandName[0].ToString().ToUpper() + commandName.Substring(1) + SuffixCommand;

        var command = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == inputCommandName);

        if(command == null)
        {
            throw new InvalidOperationException("Invalid command!");
        }

        IExecutable instanceCommand = (IExecutable)Activator.CreateInstance(command, new object[] { data, this.repository, this.unitFactory });

        return instanceCommand;
    }
}