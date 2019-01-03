using System;

public class Foodfactory
{
    public Food GetFood()
    {
        var input = Console.ReadLine().Split();
        var foodType = input[0];
        var quantity = int.Parse(input[1]);

        Food food = null;
        switch (foodType)
        {
            case "Vegetable":
                food = new Vegetable(quantity);
                break;
            case "Fruit":
                food = new Fruit(quantity);
                break;
            case "Meat":
                food = new Meat(quantity);
                break;
            case "Seeds":
                food = new Seeds(quantity);
                break;
            default:
                break;
        }

        return food;
    }
}