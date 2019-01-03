using System;

public class PriceCalculator
{
    decimal pricePerDay;
    int daysCount;
    Seasons season;
    Discounts discount;

    public PriceCalculator(string command)
    {
        var input = command.Split();
        pricePerDay = decimal.Parse(input[0]);
        daysCount = int.Parse(input[1]);
        season = Enum.Parse<Seasons>(input[2]);
        discount = Discounts.None;
        if (input.Length > 3)
        {
            discount = Enum.Parse<Discounts>(input[3]);
        }
    }

  

    public string CalculatePrice()
    {
        var totalPrice = (daysCount * pricePerDay) * (int)season;
        totalPrice = totalPrice - ((totalPrice * (int)discount) / 100);
    
        return $"{totalPrice:f2}";
    }
}


