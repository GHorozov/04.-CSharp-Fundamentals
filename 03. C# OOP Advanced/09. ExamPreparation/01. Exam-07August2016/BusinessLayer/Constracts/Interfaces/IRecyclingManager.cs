namespace _01.Exam_07August2016.BusinessLayer.Constracts.Core
{
    public interface IRecyclingManager
    {
        string ProcessGarbage(string name, double weight, double volume, string type);

        string Status();
    }
}
