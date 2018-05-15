namespace _01.Exam_07August2016.BusinessLayer.Entities.Garbages
{
    using _01.Exam_07August2016.BusinessLayer.Attrebutes;
    using _01.Exam_07August2016.BusinessLayer.Strategies;

    [BurnableStrategy(typeof(BurnableGarbageDisposalStrategy))]
    public class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double volumePerKg, double weight) 
            : base(name, volumePerKg, weight)
        {
        }
    }
}
