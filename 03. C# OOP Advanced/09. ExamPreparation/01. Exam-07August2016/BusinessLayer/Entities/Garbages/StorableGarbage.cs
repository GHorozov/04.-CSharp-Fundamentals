namespace _01.Exam_07August2016.BusinessLayer.Entities.Garbages
{
    using _01.Exam_07August2016.BusinessLayer.Attributes;
    using _01.Exam_07August2016.BusinessLayer.Strategies;

    [StorableStrategy(typeof(StorableGarbageDisposalStrategy))]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double volumePerKg, double weight) 
            : base(name, volumePerKg, weight)
        {
        }
    }
}
