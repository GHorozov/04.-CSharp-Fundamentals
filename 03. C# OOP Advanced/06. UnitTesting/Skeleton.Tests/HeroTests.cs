using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestFuxture]
public class HeroTests
{
    [Test]
    public void HeroGetsExperiancePointsAfterKillTarget()
    {
        Hero hero= new Hero("Pesho", new Axe(10, 10));
        Dummy dummy = new Dummy(10, 10);

        hero.Attack(dummy);

        //Assert
        Assert.AreEqual(10, hero.Experience, "Hero doesn't get experiance");
    }

    [Test]
    public void MockingTest()
    {
        Mock<IWeapon> weapon = new Mock<IWeapon>();

        weapon.Setup(w => w.Attack(It.IsAny<ITarget>()));

    }
}

