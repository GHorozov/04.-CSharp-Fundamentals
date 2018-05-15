namespace _01.Exam_07August2016.BusinessLayer.Attrebutes
{
    using RecyclingStation.WasteDisposal.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    
    public class BurnableStrategyAttribute : DisposableAttribute
    {
        public BurnableStrategyAttribute(Type corespondingStrategyType)
            : base(corespondingStrategyType)
        {
        }
    }
}
