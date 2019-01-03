// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    //using FestivalManager.Core.Controllers;
    //using FestivalManager.Core.Controllers.Contracts;
    //using FestivalManager.Entities;
    //using FestivalManager.Entities.Contracts;
    //using FestivalManager.Entities.Instruments;
    //using FestivalManager.Entities.Sets;

    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Text;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void Test()
	    {
            var set1 = new Long("Set1");
            var set2 = new Long("Set2");

            var song1 = new Song("Song1", new System.TimeSpan(00, 01, 00));
            var song2 = new Song("Song1", new System.TimeSpan(00, 02, 00));
            var song3 = new Song("Song1", new System.TimeSpan(00, 03, 00));

            var ivan = new Performer("Ivan", 23);
            var gosho = new Performer("Gosho", 21);
            var maria = new Performer("Maria", 18);

            var instuments = new IInstrument[] { new Guitar()};
            var instuments2 = new IInstrument[] { new Microphone()};
            var instuments3 = new IInstrument[] { new Drums()};

            ivan.AddInstrument(new Guitar());
            gosho.AddInstrument(new Microphone());
            maria.AddInstrument(new Drums());

            set1.AddPerformer(ivan);
            set1.AddPerformer(gosho);
            set1.AddPerformer(maria);

            set1.AddSong(song1);
            set1.AddSong(song2);
            set1.AddSong(song3);

            var stage = new Stage();
            stage.AddSet(set1);
            stage.AddSet(set2);

            var sc = new SetController(stage);

            var actual = sc.PerformSets();
            var sb = new StringBuilder();
            sb.AppendLine($"1. Set1:");
            sb.AppendLine($"-- 1. Song1 (01:00)");
            sb.AppendLine($"-- 2. Song1 (02:00)");
            sb.AppendLine($"-- 3. Song1 (03:00)");
            sb.AppendLine($"-- Set Successful");
            sb.AppendLine($"2. Set2:");
            sb.AppendLine($"-- Did not perform");

            var expected = sb.ToString().TrimEnd();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            var set1 = new Long("Set1");
            var ivan = new Performer("Ivan", 23);

            IInstrument instrument = new Drums();
            ivan.AddInstrument(instrument);
            set1.AddPerformer(ivan);
            set1.AddSong(new Song("Song1", new TimeSpan(00, 01, 00)));
            set1.AddPerformer(new Performer("gosho", 34));
            var stage = new Stage();
            stage.AddSet(set1);

            var sc = new SetController(stage);
            sc.PerformSets();
            var actual = instrument.Wear;
            var expected = 100;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            var set1 = new Long("Set1");
            var ivan = new Performer("Ivan", 23);

            IInstrument instrument = new Drums();
            ivan.AddInstrument(instrument);
            set1.AddPerformer(ivan);
            set1.AddSong(new Song("Song1", new TimeSpan(00, 01, 00)));
           
            var stage = new Stage();
            stage.AddSet(set1);

            var sc = new SetController(stage);
            sc.PerformSets();
            var actual = instrument.Wear;
            var expected = 80;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}