using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class ProviderControllerTests
{
    private IEnergyRepository energyRepository;
    private IProviderController providerController;

    [SetUp]
    public void Initiator()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
    }

    [Test]
    public void Test1_TestRegisterMethod()
    {
        var result1 = this.providerController.Register(new List<string>() { "Pressure", "1", "100" });
        var result2 = this.providerController.Register(new List<string>() { "Standart", "2", "200" });
        var result3 = this.providerController.Register(new List<string>() { "Solar", "3", "300" });

        var entities = this.providerController
            .GetType()
            .GetProperties()
            .FirstOrDefault(x => x.Name == "Entities");
            

        var entityProp = (IReadOnlyCollection<IEntity>)entities.GetValue(this.providerController);


        Assert.That(entityProp.Count, Is.EqualTo(3));

        Assert.That(result1, Is.EqualTo("Successfully registered PressureProvider"));
        Assert.That(result2, Is.EqualTo("Successfully registered StandartProvider"));
        Assert.That(result3, Is.EqualTo("Successfully registered SolarProvider"));
    }

    [Test]
    public void Test2_RepairMethod()
    {
        var result = this.providerController.Repair(20);

        Assert.That(result, Is.EqualTo("Providers are repaired by 20"));
    }
    [Test]
    public void Test3_ProduceMethod()
    {
        var result1 = this.providerController.Register(new List<string>() { "Pressure", "1", "100" });
        var result2 = this.providerController.Register(new List<string>() { "Standart", "2", "100" });
        var result3 = this.providerController.Register(new List<string>() { "Solar", "3", "100" });

        var actual = this.providerController.Produce();

        var entities = this.providerController
           .GetType()
           .GetProperties()
           .FirstOrDefault(x => x.Name == "Entities");


        var entityProp = (IReadOnlyCollection<IEntity>)entities.GetValue(this.providerController);

        

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(400));
        Assert.That(actual, Is.EqualTo("Produced 400 energy today!"));
        Assert.That(this.energyRepository.EnergyStored, Is.EqualTo(400));

        var pressureProviderDurability = entityProp.FirstOrDefault(x => x.ID == 1).Durability;
        var pressureStandartDurability = entityProp.FirstOrDefault(x => x.ID == 2).Durability;
        var pressureSolarDurability = entityProp.FirstOrDefault(x => x.ID == 3).Durability;

        Assert.That(pressureProviderDurability, Is.EqualTo(600));
        Assert.That(pressureStandartDurability, Is.EqualTo(900));
        Assert.That(pressureSolarDurability, Is.EqualTo(1400));
    }
}

