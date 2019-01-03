public class PressureProvider : Provider
{
    private const double ConstDecreaseDurability = 300;
    private const double ConstEnergyOutputMultiplier = 2;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability -= ConstDecreaseDurability;
        this.EnergyOutput *= ConstEnergyOutputMultiplier;
    }
}

