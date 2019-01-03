namespace TwitterTests
{
    using Moq;
    using NUnit.Framework;
    using System;

    public class TwitterTests
    {
        [Test]
        public void TestTweetGetMethod()
        {
            var inputString = "My tweet";
            var tweet = new Tweet(inputString);
            var expected = "My tweet";
            Assert.That(tweet.GetMessage(), Is.EqualTo(expected));
        }

        [Test]
        public void TestClient_TestTweetProperty()
        {
            var tweet = new Tweet("My tweet!");
            var fakeWriter = new Mock<IWriter>();
            var fakeServer = new Mock<IServer>();
            var client = new Client(tweet, fakeWriter.Object, fakeServer.Object);
            var expected = "My tweet!";
            Assert.That(client.Tweet.TweetMessage, Is.EqualTo(expected));
        }

        [Test]
        public void TestClient_SentToServerMethod()
        {
            var tweet = new Tweet("My tweet!");
            var fakeWriter = new Mock<IWriter>();
            IServer server = new Server();
            var client = new Client(tweet, fakeWriter.Object, server);
            client.SentToServer();
            var expected = "My tweet!";
            Assert.That(server.Messages[0].TweetMessage, Is.EqualTo(expected));
        }
    }
}
