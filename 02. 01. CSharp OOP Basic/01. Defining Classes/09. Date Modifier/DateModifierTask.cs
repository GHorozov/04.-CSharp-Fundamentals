using System;

class DateModifierTask
{
    static void Main(string[] args)
    {
        var firstDate = Console.ReadLine().Replace(' ', '/');
        var secondDate = Console.ReadLine().Replace(' ', '/');

        var dateModifier = new DateModifier(firstDate, secondDate);
        var result = dateModifier.GetDifference();
        Console.WriteLine(result);
    }
}

