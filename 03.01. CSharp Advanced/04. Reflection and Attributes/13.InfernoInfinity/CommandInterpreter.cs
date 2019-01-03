using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class CommandInterpreter :ICommandInterpreter
{
    private const string Suffix = "Command";

    private IRepository repository;
    private IWeaponFactory weaponFatory;
    private IGemFactory gemFactory;

    public CommandInterpreter(IRepository repository, IWeaponFactory weaponFatory, IGemFactory gemFactory)
    {
        this.repository = repository;
        this.weaponFatory = weaponFatory;
        this.gemFactory = gemFactory; 
    }


    public IExecutable InterpretCommand(string[] data)
    {
        var commandName = data[0] + Suffix;
        Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);
        if (commandType == null)
        {
            throw new InvalidOperationException("Invalid command!");
        }
        var commandInstance = (IExecutable)Activator.CreateInstance(commandType, new object[] { data });
        InjectDependancies(commandInstance);

        return commandInstance;
    }

    private void InjectDependancies(IExecutable command)
    {
        var injectAttrType = typeof(InjectAttribute);
        var commandType = command.GetType();
        var commandFields = commandType
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(x => x.GetCustomAttributes().Any(a => a.GetType() == injectAttrType))
            .ToArray();

        var interpreterFields = this.GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var field in commandFields)
        {
            field.SetValue(command,
                interpreterFields.First(x => x.FieldType == field.FieldType).GetValue(this));
        }
    }
}

