namespace SkeletonTests
{
    using NUnit.Framework;
    using System;

    public class DummyTests
    {
        [Test]
        public void DummyLossesHealthAfterAttack()
        {
            var attackValue = 5;
            var expectedValue = 15;
            var dummy = new Dummy(20, 20);
            dummy.TakeAttack(attackValue);
            Assert.That(dummy.Health, Is.EqualTo(expectedValue));
        }

        [Test]
        public void DummyThrowsExeptionIfIsDead()
        {
            var dummy = new Dummy(-5, 20);
            Assert.IsTrue(dummy.IsDead());
        }

        [Test]
        public void DeadDummyGiveExperience()
        {
            var expectedValue = 20;
            var dummy = new Dummy(-5, 20);
            dummy.GiveExperience();
            Assert.That(dummy.GiveExperience(), Is.EqualTo(expectedValue));
        }

        [Test]
        public void AliveDummyDoesNotGiveExperience()
        {
            var dummy = new Dummy(5, 20);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
