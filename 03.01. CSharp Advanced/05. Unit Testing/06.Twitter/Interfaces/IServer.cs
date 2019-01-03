using System;
using System.Collections.Generic;
using System.Text;

public interface IServer
{
    List<Tweet> Messages { get; set; }

    void AddTweetToServer(Tweet tweet);
}

