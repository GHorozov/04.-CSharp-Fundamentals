using System;
using System.Collections.Generic;
using System.Text;

public class Client
{
    private IWriter writer;
    private IServer server;

    public Client(Tweet tweet, IWriter writer, IServer server)
    {
        this.Tweet = tweet;
        this.writer = writer;
        this.server = server;
        PrintToConsole();
        SentToServer();
    }

    public void SentToServer()
    {
        this.server.AddTweetToServer(this.Tweet);
    }

    public Tweet Tweet { get; private set; }

    public void PrintToConsole()
    {
        this.writer.WriteLine(this.Tweet.GetMessage());
    }
}

