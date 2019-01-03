namespace _09.PizzaCalories
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var inputName = Console.ReadLine().Split();
                var pizzaName = inputName[1];
                var dough = Console.ReadLine().Split();
                var pizzaDough = new Dough(dough[1], dough[2], double.Parse(dough[3]));
                var pizza = new Pizza(pizzaName, pizzaDough);
                string inputTopping;
                while ((inputTopping = Console.ReadLine()) != "END")
                {
                    var linePart = inputTopping.Split();
                    var topping = new Topping(linePart[1], double.Parse(linePart[2]));
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
