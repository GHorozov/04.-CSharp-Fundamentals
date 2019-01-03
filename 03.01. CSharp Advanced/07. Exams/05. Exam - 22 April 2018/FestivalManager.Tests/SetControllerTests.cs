// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;

    using NUnit.Framework;
    using System;

    [TestFixture]
	public class SetControllerTests
    {
        private IStage stage;
        private ISetController setController;

        [SetUp]
        public void Initialize()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
        }

		[Test]
	    public void TestSetDidNotPerform()
	    {
            var set = new Short("Set1");
            this.stage.AddSet(set);

            var actual = this.setController.PerformSets();
            var expected = $@"1. Set1:
-- Did not perform";

            Assert.That(actual, Is.EqualTo(expected));
		}

        [Test]
        public void TestSetPerform()
        {
            var set = new Short("Set1");
            var instrumentGuitar = new Guitar();
            var instrumentDrums = new Drums();
            var performer = new Performer("Ivan", 23);
            var song1 = new Song("Song1", new TimeSpan(0, 1, 1));

            this.stage.AddSet(set);
            performer.AddInstrument(instrumentGuitar);
            performer.AddInstrument(instrumentDrums);
            set.AddPerformer(performer);
            set.AddSong(song1);


            var actual = this.setController.PerformSets();
            var expected = $@"1. Set1:
-- 1. Song1 (01:01)
-- Set Successful";

            var actualInstrumentWear = instrumentGuitar.Wear;
            var expectedInstrumentWear = 40;

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actualInstrumentWear, Is.EqualTo(expectedInstrumentWear));
        }
    }
}