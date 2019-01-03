namespace CosmosX.Tests
{
    using CosmosX.Entities.Containers;
    using CosmosX.Entities.Modules.Absorbing;
    using CosmosX.Entities.Modules.Absorbing.Contracts;
    using CosmosX.Entities.Modules.Energy;
    using CosmosX.Entities.Modules.Energy.Contracts;

    using NUnit.Framework;

    [TestFixture]
    public class ModuleContainerTests
    {
        [Test]
        public void TestAddEnergyModules()
        {
            var capacity = 10;
            ModuleContainer moduleContainer = new ModuleContainer(capacity);

            IEnergyModule module1 = new CryogenRod(1, 100);

            moduleContainer.AddEnergyModule(module1);

            var actual = moduleContainer.TotalEnergyOutput;
            var expected = 100;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestAddEnergyModulesWithNull()
        {
            var capacity = 10;
            ModuleContainer moduleContainer = new ModuleContainer(capacity);

            Assert.That(() => moduleContainer.AddEnergyModule(null), Throws.ArgumentException);
        }

        [Test]
        public void TestAddEnergyModulesWithOverCapacity()
        {
            var capacity = 1;
            ModuleContainer moduleContainer = new ModuleContainer(capacity);

            var module1 = new CryogenRod(1, 100);
            var modele2 = new CryogenRod(2, 200);

            var actual = moduleContainer.TotalEnergyOutput;
            var expected = 0;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestAddAbsorbingModules()
        {
            var capacity = 10;
            ModuleContainer moduleContainer = new ModuleContainer(capacity);

            IAbsorbingModule module1 = new HeatProcessor(1, 100);

            moduleContainer.AddAbsorbingModule(module1);

            var actual = moduleContainer.TotalHeatAbsorbing;
            var expected = 100;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestAddAbsorbingModulesWithNull()
        {
            var capacity = 10;
            ModuleContainer moduleContainer = new ModuleContainer(capacity);

            Assert.That(() => moduleContainer.AddAbsorbingModule(null), Throws.ArgumentException);
        }

        [Test]
        public void TestAddAbsorbingModulesWithOverCapacity()
        {
            var capacity = 1;
            ModuleContainer moduleContainer = new ModuleContainer(capacity);

            var module1 = new HeatProcessor(1, 100);
            var modele2 = new CooldownSystem(2, 200);

            var actual = moduleContainer.TotalHeatAbsorbing;
            var expected = 0;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestProperties()
        {
            var capacity = 10;
            ModuleContainer moduleContainer = new ModuleContainer(capacity);

            var modele1 = new CryogenRod(1, 100);
            var module2 = new HeatProcessor(2, 200);
            var module3 = new CooldownSystem(3, 300);

            moduleContainer.AddEnergyModule(modele1);
            moduleContainer.AddAbsorbingModule(module2);
            moduleContainer.AddAbsorbingModule(module3);


            var actual = moduleContainer.ModulesByInput.Count;
            var expected = 3;

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(moduleContainer.TotalEnergyOutput, Is.EqualTo(100));
            Assert.That(moduleContainer.TotalHeatAbsorbing, Is.EqualTo(500));
        }

        [Test]
        public void TestWhenCapacityIsEqualToInputModule()
        {
            var capacity = 1;
            ModuleContainer moduleContainer = new ModuleContainer(capacity);

            var modele1 = new CryogenRod(1, 100);
            moduleContainer.AddEnergyModule(modele1);

            var module2 = new HeatProcessor(2, 200);
            moduleContainer.AddAbsorbingModule(module2);

            var actualEnergy = moduleContainer.TotalEnergyOutput;
            var expectedEnergy = 0; 
            var actualAbsorbsion = moduleContainer.TotalHeatAbsorbing;
            var expectedAbsorbtion = 200;

            var actualModuleIntut = moduleContainer.ModulesByInput.Count;
            var expectedModuleInput = 1; 

            Assert.That(actualEnergy, Is.EqualTo(expectedEnergy));
            Assert.That(actualAbsorbsion, Is.EqualTo(expectedAbsorbtion));
            Assert.That(actualModuleIntut, Is.EqualTo(expectedModuleInput));
        }
    }
}