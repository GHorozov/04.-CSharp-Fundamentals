using System;
using System.Collections.Generic;
using System.Text;

public class Server : IServer
{
    public Server()
    {
        this.Messages = new List<Tweet>();
    }

    public List<Tweet> Messages { get; set; }

    public void AddTweetToServer(Tweet tweet)
    {
        this.Messages.Add(tweet);
    }
}

