namespace Travel.Core.IO
{
    using System.IO;
	using Contracts;

	public class StringReader : IReader
	{
		private readonly StringReader reader;

		public StringReader(string contents)
		{
			this.reader = new StringReader(contents);
		}

		public string ReadLine() => this.reader.ReadLine();
	}
}