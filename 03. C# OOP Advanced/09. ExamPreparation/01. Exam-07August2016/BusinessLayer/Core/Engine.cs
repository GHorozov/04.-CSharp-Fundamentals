namespace _01.Exam_07August2016.BusinessLayer.Core
{
    using _01.Exam_07August2016.BusinessLayer.Constracts.Core;
    using _01.Exam_07August2016.BusinessLayer.Constracts.IO;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine : IEngine
    {
        private const string TerminatingCommand = "TimeToRecycle";

        private readonly MethodInfo[] RecyclingManagerMethods;
                
        //I create reader and writer to use them in this Engine class
        private IReader reader;
        private IWriter writer;
        private IRecyclingManager recyclingManager;

        public Engine(IReader reader, IWriter writer, IRecyclingManager recyclingManager)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.RecyclingManager = recyclingManager;

            this.RecyclingManagerMethods = this.RecyclingManager.GetType()
                .GetMethods();
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }
            private set
            {
                this.reader = value;
            }
        }

        public IWriter Writer
        {
            get
            {
                return this.writer;
            }
            private set
            {
                this.writer = value;
            }
        }

        public IRecyclingManager RecyclingManager { get => recyclingManager; set => recyclingManager = value; }

        public void Run()
        {
            string input;
            while ((input = Reader.ReadLine()) != TerminatingCommand)
            {
                string[] commandArgs = SplitStringByChar(input, ' '); //Use method SplitStringByChar to split.
                string methodName = commandArgs[0];
                string[] methodNonParseParams = null; //make defalt array value;

                if (commandArgs.Length == 2) //If there are parameters in commandArgs 
                {
                    methodNonParseParams = SplitStringByChar(commandArgs[1], '|');//Use method SplitStringByChar to split.
                }

                //From all methods take that with current method name ingoring Case;
                MethodInfo methodToInvoke = this.RecyclingManagerMethods.FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));
                ParameterInfo[] methodParams = methodToInvoke.GetParameters(); // take all parameters from methosToInvoke.

                object[] parsedParams = new object[methodParams.Length];

                for (int i = 0; i < methodParams.Length; i++) 
                {
                    Type currentParamType = methodParams[i].ParameterType; //Take type of current parameter;

                    string toConvert = methodNonParseParams[i]; //Take from unparseParams current methodParams parameter

                    parsedParams[i] = Convert.ChangeType(toConvert, currentParamType); //Convert type from unparse parameter to current parameter type.
                    //This is the way to parse all parameters to corect type
                }

                object result = methodToInvoke.Invoke(this.RecyclingManager, parsedParams); //Invoke method from RecyclingStation with corect parameters.

                this.Writer.GatherOutput(result.ToString());
            }

            this.Writer.WriteGatherOutput();
        }

        private string[] SplitStringByChar(string toSplit, params char[] toSplitBy)
        {
            return toSplit.Split(toSplitBy, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
