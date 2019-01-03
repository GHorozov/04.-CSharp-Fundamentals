using System;
using System.Collections.Generic;
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

        if (command == null)
        {
            throw new InvalidOperationException("Invalid command!");
        }

        IExecutable instanceCommand = (IExecutable)Activator.CreateInstance(command, new object[] { data });

        InjectDependencies(instanceCommand);//inject nessesary fields trough inject attribute

        return instanceCommand;
    }

    private void InjectDependencies(IExecutable command)
    {
        Type injectAttrType = typeof(InjectAttribute);

        var fieldsForInjection = command
            .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(x => x.GetCustomAttributes().Any(a => a.GetType() == injectAttrType));

        var interpeterFields = this.GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo field in fieldsForInjection)
        {
            field
                .SetValue(command, interpeterFields.First(x => x.FieldType == field.FieldType)
                .GetValue(this));
        }

    }
}