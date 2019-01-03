using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string mode = "Full";
    private double totalStoredEnergy;
    private double totalMinedOre;
    private IList<Harvester> harvesters;
    private IList<Provider> providers;

    public DraftManager()
    {
        this.totalMinedOre = 0;
        this.totalStoredEnergy = 0;
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            this.harvesters.Add(HarvesterFactory.GetHarvester(arguments));
            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        
    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            this.providers.Add(ProviderFactory.GetProvider(arguments));
            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
       
    }
    public string Day()
    { 
        var energyProvided = this.providers.Select(x => x.EnergyOutput).Sum();
        this.totalStoredEnergy += energyProvided;
        var allHarvestersEnergyNeeds = this.harvesters.Select(x => x.EnergyRequirement).Sum();
        var oreProduced = 0.0;

        if (this.totalStoredEnergy >= allHarvestersEnergyNeeds)
        {
            switch (this.mode)
            {
                case "Full":
                    this.totalStoredEnergy -= allHarvestersEnergyNeeds;
                    oreProduced = this.harvesters.Select(x => x.OreOutput).Sum();
                    break;
                case "Half":
                    this.totalStoredEnergy -= (allHarvestersEnergyNeeds * 0.6);
                    oreProduced = this.harvesters.Select(x => x.OreOutput).Sum() * 0.5;
                    break;
                case "Energy":
                    break;
            }
        }

        this.totalMinedOre += oreProduced; 

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {energyProvided}");
        sb.AppendLine($"Plumbus Ore Mined: {oreProduced}");

        return sb.ToString().TrimEnd();
    }
    public string Mode(List<string> arguments)
    {
        var modeName = arguments[0];
        this.mode = modeName;
        return $"Successfully changed working mode to {modeName} Mode";
    }
    public string Check(List<string> arguments)
    {
        string result = string.Empty;
        var inputId = arguments[0];

        var currentHarvester = this.harvesters.FirstOrDefault(x => x.Id == inputId);
        var currentProvider = this.providers.FirstOrDefault(x => x.Id == inputId);

        if (currentHarvester == null && currentProvider == null)
        {
            result =  $"No element found with id - {inputId}";
        }
        else if(currentHarvester != null)
        {
            result = currentHarvester.ToString();
        }
        else if(currentProvider != null)
        {
            result = currentProvider.ToString();
        }

        return result;
    }
    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString().TrimEnd();
    }
}