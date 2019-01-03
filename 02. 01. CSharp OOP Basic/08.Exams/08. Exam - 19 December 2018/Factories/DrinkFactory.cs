using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class DrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = null;
            if(type == "FuzzyDrink")
            {
                drink = new FuzzyDrink(name, servingSize, brand);
            }
            else if (type == "Juice")
            {
                drink = new Juice(name, servingSize, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, servingSize, brand);
            }
            else if (type == "Alcohol")
            {
                drink = new Alcohol(name, servingSize, brand);
            }
            else
            {
                throw new InvalidOperationException("Invalid drink type!");
            }

            return drink;
        } 
    }
}
