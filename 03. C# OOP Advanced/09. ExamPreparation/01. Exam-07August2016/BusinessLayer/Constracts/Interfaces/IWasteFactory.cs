namespace _01.Exam_07August2016.BusinessLayer.Constracts.Interfaces
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public interface IWasteFactory
    {
        IWaste Create(string name, double weight, double volumePerKg, string type);
    }
}
