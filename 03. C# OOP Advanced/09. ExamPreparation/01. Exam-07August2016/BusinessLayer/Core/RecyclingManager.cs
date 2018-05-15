namespace _01.Exam_07August2016.BusinessLayer.Core
{
    using System;
    using _01.Exam_07August2016.BusinessLayer.Constracts.Core;
    using RecyclingStation.WasteDisposal.Interfaces;
    using _01.Exam_07August2016.BusinessLayer.Constracts.Interfaces;

    public class RecyclingManager : IRecyclingManager
    {
        //Constants messages.
        private const string RequirementsChangedMessage = "Management requirement changed!";
        private const string ProcessingDeniedMessage = "Processing Denied!";

        //Constants for messages.
        private const string ProcessGarbageMessageToFormat = "{0} kg of {1} successfully processed!";
        private const string StatusMessageToFormat = "Energy: {0} Capital: {1}";
        private const string FloatingPointNumberFormat = "f2";

        private IGarbageProcessor garbageProcessor;
        private IWasteFactory wasteFactory;

        //To keep info for energy and capital balance.
        private double capitalBalance;
        private double energyBalance;

        //To keep info for minimum energy and capital balance and typeOfGarbage for current garbage type.  
        private double minimumEnergyBalance;
        private double minimumCapitalBalance;
        private string typeOfGarbage;

        //To keep track if there are some requirements.
        private bool requirenmentsAreSet;

        public RecyclingManager(IGarbageProcessor garbageProcessor, IWasteFactory wasteFactory)
        {
            this.garbageProcessor = garbageProcessor;
            this.wasteFactory = wasteFactory;
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            //Add checks for ChangedMenagementRequirement
            if (requirenmentsAreSet)
            {
                bool requirementsAreSatisfied = true;
                if (this.typeOfGarbage == type)
                {
                    requirementsAreSatisfied = this.capitalBalance >= minimumCapitalBalance && this.energyBalance >= minimumEnergyBalance;
                }

                if (!requirementsAreSatisfied)
                {
                    return ProcessingDeniedMessage;
                }
            }

            IWaste someWaste = this.wasteFactory.Create(name, weight, volumePerKg, type);

            IProcessingData processedData = this.garbageProcessor.ProcessWaste(someWaste);

            capitalBalance += processedData.CapitalBalance;
            energyBalance += processedData.EnergyBalance;

            string formatedMessage = string.Format(ProcessGarbageMessageToFormat, someWaste.Weight.ToString(FloatingPointNumberFormat), someWaste.Name);

            return formatedMessage;
        }

        public string Status()
        {
            string formatMessage = string.Format(StatusMessageToFormat, energyBalance.ToString(FloatingPointNumberFormat), capitalBalance.ToString(FloatingPointNumberFormat));

            return formatMessage;
        }


        public string ChangeManagementRequirement(double minimumEnergyBalance, double minimumCapitalBalance, string type)
        {
            this.minimumEnergyBalance = minimumEnergyBalance;
            this.minimumCapitalBalance = minimumCapitalBalance;
            this.typeOfGarbage = type;

            this.requirenmentsAreSet = true;

            return RequirementsChangedMessage;
        }
    }
}
