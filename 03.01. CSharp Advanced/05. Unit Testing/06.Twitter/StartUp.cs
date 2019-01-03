namespace _06.Twitter
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            var tweet = new Tweet("My tweet message!");
            IServer server = new Server();
            var client = new Client(tweet, writer, server);
        }
    }
}
