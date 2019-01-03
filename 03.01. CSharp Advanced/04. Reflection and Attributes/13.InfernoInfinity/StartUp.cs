namespace _13.InfernoInfinity
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IRepository repository = new Repository(writer);
            IWeaponFactory weaponFactory = new WeaponFactory();
            IGemFactory gemFactory = new GemFactory();

            var engine = new Engine(repository, weaponFactory, gemFactory);
            engine.Run();
        }
    }
}
