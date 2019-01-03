public class SolarProvider : Provider
{
    private const double ConstIncreaseDurability = 500;

    public SolarProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability += ConstIncreaseDurability;
    }
}

