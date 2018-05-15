using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MainDateModifier
{
    static void Main(string[] args)
    {
        var firstDateInput = Console.ReadLine();
        var secondDateInput = Console.ReadLine();

        var firstDate = DateTime.ParseExact(firstDateInput, "yyyy MM dd", CultureInfo.InvariantCulture);
        var secondDate = DateTime.ParseExact(secondDateInput, "yyyy MM dd", CultureInfo.InvariantCulture);

        var newDateModifier = new DateModifier(firstDate, secondDate);
        Console.WriteLine(newDateModifier.GetTwoDatesDiffrance());
    }
}

