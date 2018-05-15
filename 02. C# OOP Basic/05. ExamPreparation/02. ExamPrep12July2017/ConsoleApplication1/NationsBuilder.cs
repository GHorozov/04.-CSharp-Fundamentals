using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NationsBuilder
{
    private Nation airNation;
    private Nation fireNation;
    private Nation waterNation;
    private Nation earthNation;

    private List<Monument> airMonument;
    private List<Monument> fireMonument;
    private List<Monument> waterMonument;
    private List<Monument> earthMonument;

    private List<string> warsRecord;
    public NationsBuilder()
    {
        this.airNation = new Nation();
        this.fireNation = new Nation();
        this.waterNation = new Nation();
        this.earthNation = new Nation();
        this.airMonument = new List<Monument>();
        this.fireMonument = new List<Monument>();
        this.waterMonument = new List<Monument>();
        this.earthMonument = new List<Monument>();
        this.warsRecord = new List<string>();
    }

    public void AssignBender(List<string> lineParts)
    {
        var type = lineParts[1];
        var name = lineParts[2];
        var power = int.Parse(lineParts[3]);
        var secondaryParams = double.Parse(lineParts[4]);

        switch (type)
        {
            case "Air":
                airNation.BendersList.Add(new AirBender(name, power, secondaryParams));
                break;

            case "Water":
                waterNation.BendersList.Add(new WaterBender(name, power, secondaryParams));
                break;

            case "Fire":
                fireNation.BendersList.Add(new FireBender(name, power, secondaryParams));
                break;

            case "Earth":
                earthNation.BendersList.Add(new EarthBender(name, power, secondaryParams));
                break;
        }
    }
    public void AssignMonument(List<string> linePart)
    {
        var type = linePart[1];
        var name = linePart[2];
        var seconderyparams = int.Parse(linePart[3]);

        switch (type)
        {
            case "Air":
                airMonument.Add(new AirMonument(name, seconderyparams));
                break;

            case "Water":
                waterMonument.Add(new WaterMonument(name, seconderyparams));
                break;

            case "Fire":
                fireMonument.Add(new FireMonument(name, seconderyparams));
                break;

            case "Earth":
                earthMonument.Add(new EarthMonument(name, seconderyparams));
                break;
        }
    }
    public string GetStatus(string nationsType)
    {
        var resultNation = $"{nationsType} Nation" + Environment.NewLine + "Benders:";
        var resultMonument = $"Monuments:";


        if (nationsType == "Air")
        {
            if (this.airNation.BendersList.Count > 0)
            {
                foreach (var bender in airNation.BendersList)
                {
                    resultNation += Environment.NewLine + bender.ToString();
                }
            }
            else
            {
                resultNation += " None";
            }

            if (this.airMonument.Count > 0)
            {
                foreach (var monument in this.airMonument)
                {
                    resultMonument += Environment.NewLine + monument.ToString();
                }
            }
            else
            {
                resultMonument += " None";
            }
        }
        else if (nationsType == "Water")
        {

            if (this.waterNation.BendersList.Count > 0)
            {
                foreach (var bender in this.waterNation.BendersList)
                {
                    resultNation += Environment.NewLine + bender.ToString();
                }
            }
            else
            {
                resultNation += " None";
            }

            if (this.waterMonument.Count > 0)
            {
                foreach (var monument in this.waterMonument)
                {
                    resultMonument += Environment.NewLine + monument.ToString();
                }
            }
            else
            {
                resultMonument += " None";
            }
        }
        else if (nationsType == "Fire")
        {
            if (this.fireNation.BendersList.Count > 0)
            {
                foreach (var bender in this.fireNation.BendersList)
                {
                    resultNation += Environment.NewLine + bender.ToString();
                }
            }
            else
            {
                resultNation += " None";
            }

            if (this.fireMonument.Count > 0)
            {
                foreach (var monument in this.fireMonument)
                {
                    resultMonument += Environment.NewLine + monument.ToString();
                }
            }
            else
            {
                resultMonument += " None";
            }
        }
        else if (nationsType == "Earth")
        {
            if (this.earthNation.BendersList.Count > 0)
            {
                foreach (var bender in this.earthNation.BendersList)
                {
                    resultNation += Environment.NewLine + bender.ToString();
                }
            }
            else
            {
                resultNation += " None";
            }

            if (this.earthMonument.Count > 0)
            {
                foreach (var monument in this.earthMonument)
                {
                    resultMonument += Environment.NewLine + monument.ToString();
                }
            }
            else
            {
                resultMonument += " None";
            }

        }

        return resultNation + Environment.NewLine + resultMonument;
    }
    public void IssueWar(string nationsType)
    {
        this.warsRecord.Add(nationsType);

        var listNationPower = new List<double>();
        
        var airNationPower = (this.airNation.BendersList.Select(b => b.GetTotalPower()).Sum() / 100) * (this.airMonument.Select(m => m.GetAffinity()).Sum()) + this.airNation.BendersList.Select(b => b.GetTotalPower()).Sum();
        listNationPower.Add(airNationPower);

        var fireNationPower = (this.fireNation.BendersList.Select(b => b.GetTotalPower()).Sum() / 100) * (this.fireMonument.Select(m => m.GetAffinity()).Sum()) + this.fireNation.BendersList.Select(b => b.GetTotalPower()).Sum();
        listNationPower.Add(fireNationPower);

        var waterNationPower = (this.waterNation.BendersList.Select(b => b.GetTotalPower()).Sum() / 100) * (this.waterMonument.Select(m => m.GetAffinity()).Sum() + this.waterNation.BendersList.Select(b => b.GetTotalPower()).Sum());
        listNationPower.Add(waterNationPower);

        var earthNationPower = (this.earthNation.BendersList.Select(b => b.GetTotalPower()).Sum() / 100) * (this.earthMonument.Select(m => m.GetAffinity()).Sum() + this.earthNation.BendersList.Select(b => b.GetTotalPower()).Sum());
        listNationPower.Add(earthNationPower);

        var victorNation = listNationPower.Max();

        for (int i = 0; i < listNationPower.Count; i++)
        {
            if (listNationPower[i] != victorNation)
            {
                if (listNationPower[i] == airNationPower)
                {
                    this.airNation.BendersList.Clear();
                    this.airMonument.Clear();
                }
                if (listNationPower[i] == fireNationPower)
                {
                    this.fireNation.BendersList.Clear();
                    this.fireMonument.Clear();
                }
                if (listNationPower[i] == waterNationPower)
                {
                    this.waterNation.BendersList.Clear();
                    this.waterMonument.Clear();
                }
                if (listNationPower[i] == earthNationPower)
                {
                    this.earthNation.BendersList.Clear();
                    this.earthMonument.Clear();
                }
            }
        }

    }
    public string GetWarsRecord()
    {
        var result = "";
        for (int i = 0; i < warsRecord.Count; i++)
        {
            if (i != warsRecord.Count - 1)
            {
                result += $"War {i + 1} issued by {warsRecord[i]}" + Environment.NewLine;
            }
            else
            {
                result += $"War {i + 1} issued by {warsRecord[i]}";
            }
        }
        return result;
    }

}

