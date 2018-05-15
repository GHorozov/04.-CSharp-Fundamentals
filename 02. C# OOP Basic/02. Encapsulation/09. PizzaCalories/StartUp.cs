using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            var inputLine = Console.ReadLine();

            while(inputLine != "END")
            {
                var linePerts = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                if( linePerts[0] == "Dough")
                {
                    var newDough = new Dough(linePerts[1], linePerts[2], double.Parse(linePerts[3]));
                    Console.WriteLine($"{newDough.GetCalories():f2}");
                }
                else if(linePerts[0] == "Topping")
                {
                    var newTopping = new Topping(linePerts[1], double.Parse(linePerts[2]));
                    Console.WriteLine($"{newTopping.GetCalories():f2}");
                }
                else if(linePerts[0] == "Pizza")
                {
                    var pizzaName = linePerts[1];
                    var numberOfToppings = int.Parse(linePerts[2]);

                    if(numberOfToppings > 10)
                    {
                        Console.WriteLine("Number of toppings should be in range [0..10].");
                        return;
                    }

                    var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var dough = new Dough(input[1], input[2], double.Parse(input[3]));
                    var pizza = new Pizza(pizzaName, dough);

                    for (int i = 0; i < numberOfToppings; i++)
                    {
                        var lineTopingInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        pizza.AddToppings(new Topping(lineTopingInfo[1], double.Parse(lineTopingInfo[2])));
                    }

                    Console.WriteLine($"{pizza.Name} - {pizza.GetTotalcalories():f2} Calories.");
                }


                inputLine = Console.ReadLine();
            }



        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        
    }
}

