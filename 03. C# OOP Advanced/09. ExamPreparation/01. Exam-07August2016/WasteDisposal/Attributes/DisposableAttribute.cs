namespace RecyclingStation.WasteDisposal.Attributes
{
    using System;

    /// <summary>
    /// An attribute class, that represents the base of all Disposable Attribute classes.
    /// </summary>
    
    [AttributeUsage(AttributeTargets.Class)]
    public class DisposableAttribute : Attribute
    {
        private Type corespondingStrategyType;

        public DisposableAttribute(Type corespondingStrategyType)
        {
            this.CorespondingStrategyType = corespondingStrategyType;
        }

        public Type CorespondingStrategyType
        {
            get
            {
                return this.corespondingStrategyType;
            }

            private set
            {
                this.corespondingStrategyType = value;
            }
        }
    }
}
