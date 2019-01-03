using System;

public class FoodFactory
{
    private string food;

    public FoodFactory(string food)
    {
        this.food = food;
    }

    protected string Food
    {
        get { return food; }
        set
        {
            this.food = value;
        }
    }

    public int GetFoodPoints()
    {
        var food = 0;
        switch (this.Food.ToLower())
        {
            case "cram":
                food += 2;
                break;
            case "lembas":
                food += 3;
                break;
            case "apple":
                food += 1;
                break;
            case "melon":
                food += 1;
                break;
            case "honeycake":
                food += 5;
                break;
            case "mushrooms":
                food += -10;
                break;
            default:
                food += -1;
                break;
        }

        return food;
    }
}

