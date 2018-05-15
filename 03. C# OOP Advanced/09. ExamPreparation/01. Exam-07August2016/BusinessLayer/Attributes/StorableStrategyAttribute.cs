namespace _01.Exam_07August2016.BusinessLayer.Attributes
{
    using RecyclingStation.WasteDisposal.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StorableStrategyAttribute : DisposableAttribute
    {
        public StorableStrategyAttribute(Type corespondingStrategyType)
            : base(corespondingStrategyType)
        {
        }
    }
}
