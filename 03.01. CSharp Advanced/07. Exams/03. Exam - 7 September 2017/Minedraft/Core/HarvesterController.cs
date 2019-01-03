using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const int MinDurability = 0;

    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory harvesterFactory;
    private Mode mode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.harvesterFactory = new HarvesterFactory();
        this.mode = Mode.Full;
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        if(mode == "Energy")
        {
            this.mode = Mode.Energy;
        }
        else if(mode == "Half")
        {
            this.mode = Mode.Half;
        }
        else if(mode == "Full")
        {
            this.mode = Mode.Full;
        }

        IList<IHarvester> reminder = new List<IHarvester>();

        foreach (IHarvester harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception)
            {
                reminder.Add(harvester);
            }
        }

        foreach (IHarvester entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ChangedMode, mode);
    }

    public string Produce()
    {
        var energyNeeded = 0.0;
        foreach (var harvester in this.harvesters)
        {
            if(this.mode == Mode.Full)
            {
                energyNeeded += harvester.EnergyRequirement;
            }
            if (this.mode == Mode.Half)
            {
                energyNeeded += harvester.EnergyRequirement / 2;
            }
            if (this.mode == Mode.Energy)
            {
                energyNeeded += harvester.EnergyRequirement * 0.2;
            }
        }
       

        var oreResultToday = 0.0;
        if (this.energyRepository.TakeEnergy(energyNeeded))
        {
            foreach (var h in this.harvesters)
            {
                oreResultToday += h.Produce();
            }
        }

        if(this.mode == Mode.Half)
        {
            oreResultToday /= 2;
        }
        if(this.mode == Mode.Energy)
        {
            oreResultToday *= 0.2;
        }

        this.OreProduced += oreResultToday;

        return string.Format(Constants.OreOutputToday, oreResultToday);
    }

    public string Register(IList<string> args)
    {
        var harvester = this.harvesterFactory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }
}

