namespace _01.Exam_07August2016.BusinessLayer.IO
{
    using _01.Exam_07August2016.BusinessLayer.Constracts.IO;
    using System;
    using System.Text;

    public class ConsoleWriter : IWriter
    {
        private StringBuilder outputGetherer;

        public ConsoleWriter() : this(new StringBuilder()) // This way i can create with new String Builder 
        {

        }

        public ConsoleWriter(StringBuilder outputGetherer)
        {
            this.OutputGatherer = outputGetherer;
        }

        public StringBuilder OutputGatherer
        {
            get
            {
                return this.outputGetherer;
            }
            private set
            {
                this.outputGetherer = value;
            }
        }

        public void GatherOutput(string outputToGather)
        {
            this.OutputGatherer.AppendLine(outputToGather);
        }

        public void WriteGatherOutput()
        {
            Console.WriteLine(this.OutputGatherer);
        }
    }
}
