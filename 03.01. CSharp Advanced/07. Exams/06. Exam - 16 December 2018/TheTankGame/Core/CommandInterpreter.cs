namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters = inputParameters.Skip(1).ToArray();

            if(command == "Vehicle" || command == "Part")
            {
                command = "Add" + command;
            }

            string methodResult = (string)this.tankManager
                .GetType()
                .GetMethod(command, BindingFlags.Instance | BindingFlags.Public)
                .Invoke(this.tankManager, new object[] { inputParameters });

            return methodResult;
        }
    }
}