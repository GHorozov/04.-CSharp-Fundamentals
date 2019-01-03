namespace SkeletonTests
{
    using NUnit.Framework;
    using System;

    public class AxeTests
    {
        [Test]
        public void AxeLossesDurabilityAfterAttack()
        {
            //Arrange
            var expectedValue = 9;
            var axe = new Axe(5, 10);
            var dummy = new Dummy(20, 20);
            //Act
            axe.Attack(dummy);
            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedValue)); //first way
            //Assert.AreEqual(expectedValue, axe.DurabilityPoints); //second way
        }

        [Test]
        public void BrokenAxeCannotAttack()
        {
            var axe = new Axe(5, 0); 
            var dummy = new Dummy(20, 20);
            
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}
