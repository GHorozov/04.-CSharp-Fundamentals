namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Linq;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class GarbageProcessor : IGarbageProcessor
    {
        //private IStrategyHolder strategyHolder;

        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public IStrategyHolder StrategyHolder { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            Type type = garbage.GetType(); //take garbage type.

            //Take attribute (if there is one) for current strategy. 
            DisposableAttribute disposalAttribute = (DisposableAttribute)type.GetCustomAttributes(typeof(DisposableAttribute), true).FirstOrDefault();
            
            if (disposalAttribute == null) //If there isn't throw exeption
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            Type typeOfAttribute = disposalAttribute.GetType(); //take from disposableAttribute his type.

            if (!this.StrategyHolder.GetDisposalStrategies.ContainsKey(typeOfAttribute)) //Check if in strategies have key with this current starategy. If there isn't key I make key to have this key in future. 
            {
                Type typeOfCorespondingStrategy = disposalAttribute.CorespondingStrategyType; //Take type of current strategy to be used.

                IGarbageDisposalStrategy activatedStrategy = (IGarbageDisposalStrategy)Activator.CreateInstance(typeOfCorespondingStrategy); //Make instance for current strategy.

                this.StrategyHolder.AddStrategy(typeOfAttribute, activatedStrategy); // Add key to dict with strategies.
            }

            IGarbageDisposalStrategy currentStrategy = this.StrategyHolder.GetDisposalStrategies[typeOfAttribute]; //Take maked strategy.

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}
