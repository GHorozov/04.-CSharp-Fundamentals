﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CosmosX.Core.Contracts;

namespace CosmosX.Core
{
    public class CommandParser : ICommandParser
    {
        private const string CommandNameSuffix = "Command";
        private readonly IManager reactorManager;

        public CommandParser(IManager reactorManager)
        {
            this.reactorManager = reactorManager;
        }

        public string Parse(IList<string> arguments)
        {
            string command = arguments[0] + CommandNameSuffix;
            string[] commandArguments = arguments.Skip(1).ToArray();

            string result = (string)this.reactorManager
                .GetType()
                .GetMethod(command, BindingFlags.Instance | BindingFlags.Public)
                .Invoke(this.reactorManager, new object[] { commandArguments });

            return result;
        }
    }
}