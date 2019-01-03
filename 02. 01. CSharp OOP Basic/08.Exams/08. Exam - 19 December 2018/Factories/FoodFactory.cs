using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class FoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            IFood food = null;
            if(type == "Dessert")
            {
                food = new Dessert(name,price);
            }
            else if (type == "Salad")
            {
                food = new Salad(name, price);
            }
            else if (type == "Soup")
            {
                food = new Soup(name, price);
            }
            else if (type == "MainCourse")
            {
                food = new MainCourse(name, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid food type!");
            }

            return food;
        }
    }
}
