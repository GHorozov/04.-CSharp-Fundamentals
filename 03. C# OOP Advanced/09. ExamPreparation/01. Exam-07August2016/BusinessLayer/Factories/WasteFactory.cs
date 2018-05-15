namespace _01.Exam_07August2016.BusinessLayer.Factories
{
    using _01.Exam_07August2016.BusinessLayer.Constracts.Interfaces;
    using RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Reflection;
    using System.Linq;

    public class WasteFactory : IWasteFactory
    {
        private const string GarbageSuffix = "Garbage";

        public IWaste Create(string name, double weight, double volumePerKg, string type)
        {
            string fullTypeName = type + GarbageSuffix;

            Type typeOfGarbageToActivate = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(fullTypeName, StringComparison.OrdinalIgnoreCase));

            object[] typeArgs = new Object[] { name, weight, volumePerKg }; //Make object with current params to pass in Activator.

            IWaste waste = (IWaste)Activator.CreateInstance(typeOfGarbageToActivate, typeArgs); //Make instance to current garbage. 

            //II-way to crate make instance without typeArgs variable.
            //IWaste waste = (IWaste)Activator.CreateInstance(typeOfGarbageToActivate, name, weight, volumePerKg);
            return waste;
        }
    }
}
