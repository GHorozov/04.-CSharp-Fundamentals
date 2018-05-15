namespace _01.Exam_07August2016.BusinessLayer.Strategies
{
    using System;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            return 0;
        }

        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            double energyProduced = garbage.CalculateWasteTotalVolume();
            double energyUsed = garbage.CalculateWasteTotalVolume() * 0.2;

            return energyProduced - energyUsed;
        }
    }
}
