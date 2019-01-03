namespace DungeonsAndCodeWizards
{
    using System;
    using DungeonsAndCodeWizards.Core;
    using DungeonsAndCodeWizards.Core.Interfaces;
    using DungeonsAndCodeWizards.Core.IO;
    
    public class StartUp
    {
        static void Main(string[] args)
        {
           IReader reader = new ConsoleReader();
           IWriter writer = new ConsoleWriter();
                
           Engine engine = new Engine(reader, writer);
           engine.Run();
        }
    }
}
