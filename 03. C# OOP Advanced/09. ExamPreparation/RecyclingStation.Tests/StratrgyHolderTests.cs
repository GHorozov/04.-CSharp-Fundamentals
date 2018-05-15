using _01.Exam_07August2016.BusinessLayer.Attrebutes;
using _01.Exam_07August2016.BusinessLayer.Attributes;
using _01.Exam_07August2016.BusinessLayer.Strategies;
using NUnit.Framework;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[TestFixture]
public class StratrgyHolderTests
{
    //Make common variables here to avoid repeating usage
    private IGarbageDisposalStrategy ds;
    private Dictionary<Type, IGarbageDisposalStrategy> strategies;

    [SetUp]
    public void TestInit()
    {
        ds = new BurnableGarbageDisposalStrategy();
        strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
    }


    [Test]
    public void TestPropertyForReadOnlyCollection()
    {
        //Arrange
        Type disType = typeof(DisposableAttribute);
        IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        Type type = sut.GetDisposalStrategies.GetType();


        //Assert
        Assert.IsTrue(type.GetInterfaces().Contains(typeof(IReadOnlyCollection<>)));
    }


    [Test]
    public void AddStrategy()
    {
        //Arrange
        IGarbageDisposalStrategy ds = new BurnableGarbageDisposalStrategy();
        Type disType = typeof(DisposableAttribute);
        Dictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        var type = sut.AddStrategy(disType, ds);


        //Assert
        Assert.IsTrue(sut.AddStrategy(disType,ds));
    }

    [Test]
    public void AddSameStrategyAndCheckCollectionHaveOne()
    {
        //Arrange
        IGarbageDisposalStrategy ds = new BurnableGarbageDisposalStrategy();
        Type disType = typeof(DisposableAttribute);
        Dictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        bool result = sut.AddStrategy(disType, ds);
        bool result1 = sut.AddStrategy(disType, ds);
        bool result2 = sut.AddStrategy(disType, ds);


        //Assert
        Assert.AreEqual(1, sut.GetDisposalStrategies.Count);
    }

    [Test]
    public void AddDiffrentStrategiesAndCheckCollection()
    {
        //Arrange
        IGarbageDisposalStrategy ds = new BurnableGarbageDisposalStrategy();
        Type disType = typeof(BurnableStrategyAttribute);
        Type disType1 = typeof(StorableStrategyAttribute);
        Type disType2 = typeof(RecyclableStrategyAttribute);
        Dictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        bool result = sut.AddStrategy(disType, ds);
        bool result1 = sut.AddStrategy(disType1, ds);
        bool result2 = sut.AddStrategy(disType2, ds);


        //Assert
        Assert.AreEqual(3, sut.GetDisposalStrategies.Count);
    }

    [Test]
    public void RemoveStrategies()
    {
        //Arrange
        IGarbageDisposalStrategy ds = new BurnableGarbageDisposalStrategy();
        Type disType = typeof(DisposableAttribute);
        Dictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        bool result = sut.AddStrategy(disType, ds);


        //Assert
        Assert.IsTrue(sut.RemoveStrategy(disType));
    }

    [Test]
    public void RemoveStrategiesAndCheckCount()
    {
        //Arrange
        IGarbageDisposalStrategy ds = new BurnableGarbageDisposalStrategy();
        Type disType = typeof(BurnableStrategyAttribute);
        Type disType1 = typeof(StorableStrategyAttribute);
        Type disType2 = typeof(RecyclableStrategyAttribute);
        Dictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        bool result = sut.AddStrategy(disType, ds);
        bool result1 = sut.AddStrategy(disType1, ds);
        bool result2 = sut.AddStrategy(disType2, ds);

        var removeResults = sut.RemoveStrategy(disType);
        
        //Assert
        Assert.AreEqual(2, sut.GetDisposalStrategies.Count);
    }
}

