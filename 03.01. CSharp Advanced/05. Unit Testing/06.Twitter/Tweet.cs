public class Tweet :IMessage
{
    public Tweet(string tweetMessage)
    {
        this.TweetMessage = tweetMessage;
    }

    public string TweetMessage { get; set; }

    public string GetMessage()
    {
        return this.TweetMessage;
    }
}

