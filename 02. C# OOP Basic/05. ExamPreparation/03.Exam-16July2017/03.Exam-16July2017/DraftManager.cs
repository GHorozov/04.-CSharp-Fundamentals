using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;

    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    private double totalStoredEnergy;
    private double totalMinedOre;

    private string workingMode;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();

        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();

        this.workingMode = "Full";
    }


    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[1];
        var id = arguments[2];

        try
        {
            harvesters.Add(this.harvesterFactory.Get(arguments));
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }

        return $"Successfully registered {type} Harvester - {id}";
    }
    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[1];
        var id = arguments[2];

        try
        {
            providers.Add(this.providerFactory.RegisterProvider(arguments));
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }

        return $"Successfully registered {type} Provider - {id}";
    }
    public string Day()
    {
        var allNeededEnergy = 0.0;

        var currentStoreEnergy = 0.0;
        var currentProduceOre = 0.0;


        if (this.workingMode == "Full")
        {
            currentStoreEnergy = this.providers.Sum(p => p.EnergyOutput);
            allNeededEnergy = harvesters.Sum(h => h.EnergyRequirement);

            this.totalStoredEnergy += currentStoreEnergy;

            if (this.totalStoredEnergy >= allNeededEnergy)
            {
                currentProduceOre = harvesters.Sum(c => c.OreOutput);

                this.totalStoredEnergy -= allNeededEnergy;
            }
        }
        else if (this.workingMode == "Half")
        {
            currentStoreEnergy = providers.Sum(p => p.EnergyOutput);
            allNeededEnergy = harvesters.Sum(h => h.EnergyRequirement) * 0.6;

            this.totalStoredEnergy += currentStoreEnergy;

            if (this.totalStoredEnergy >= allNeededEnergy)
            {
                currentProduceOre = harvesters.Sum(h => h.OreOutput) * 0.5;

                this.totalStoredEnergy -= allNeededEnergy;
            }
        }
        else if (this.workingMode == "Energy")
        {
            currentStoreEnergy = providers.Sum(p => p.EnergyOutput);

            this.totalStoredEnergy += currentStoreEnergy;
        }

        this.totalMinedOre += currentProduceOre;

        var sb = new StringBuilder();
        sb.AppendLine($"A day has passed.");
        sb.AppendLine($"Energy Provided: {currentStoreEnergy}");
        sb.AppendLine($"Plumbus Ore Mined: {currentProduceOre}");

        return sb.ToString().Trim();
    }
    public string Mode(List<string> arguments)
    {
        var currentMode = arguments[1];
        this.workingMode = currentMode;

        return $"Successfully changed working mode to {this.workingMode} Mode";
    }
    public string Check(List<string> arguments)
    {
        var id = arguments[1];

        if (this.harvesters.Any(h => h.Id == id))
        {
            return this.harvesters.First(h => h.Id == id).ToString();
        }

        if (this.providers.Any(p => p.Id == id))
        {
            return this.providers.First(p => p.Id == id).ToString();
        }

        return $"No element found with id - {id}";
    }
    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString().Trim();
    }
}

