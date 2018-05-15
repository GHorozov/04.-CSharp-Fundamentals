using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {
        var calc = new PrimitiveCalculator();

        string input;
        while ((input=Console.ReadLine()) != "End")
        {
            var paramArgs = input.Split(' ');
            var first = paramArgs[0];
            var second = paramArgs[1];

            if(first == "mode")
            {
                calc.ChangeStrategy(char.Parse(second));
            }
            else
            {
                Console.WriteLine(calc.PerformCalculation(int.Parse(first), int.Parse(second)));
            }


        }
    }
}

