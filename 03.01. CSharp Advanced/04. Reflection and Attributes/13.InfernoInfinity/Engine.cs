using System;
using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IRepository repository;
    private IWeaponFactory weaponFactory;
    private IGemFactory gemFactory;

    public Engine(IRepository repository,IWeaponFactory weaponFactory, IGemFactory gemFactory)
    {
        this.repository = repository;
        this.weaponFactory = weaponFactory;
        this.gemFactory = gemFactory;
        this.commandInterpreter = new CommandInterpreter(this.repository, this.weaponFactory, this.gemFactory);
    }

    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                var lineArgs = input.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = lineArgs[0];
                this.commandInterpreter.InterpretCommand(lineArgs).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
