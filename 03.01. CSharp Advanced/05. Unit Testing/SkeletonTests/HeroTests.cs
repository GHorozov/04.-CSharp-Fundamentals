using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class HeroTests
{
    [Test]
    public void IsHeroGetXpWhenDummyDie()
    {
        var experienceGained = 5;

        Mock<ITarget> fakeDummy = new Mock<ITarget>();
        fakeDummy.Setup(x => x.IsDead()).Returns(true);
        fakeDummy.Setup(x => x.GiveExperience()).Returns(experienceGained);

        Mock<IWeapon> fakeAxe = new Mock<IWeapon>();

        var fakeHero = new Hero("MyHero", fakeAxe.Object);
        fakeHero.Attack(fakeDummy.Object);

        Assert.That(fakeHero.Experience, Is.EqualTo(experienceGained));
    }

}

