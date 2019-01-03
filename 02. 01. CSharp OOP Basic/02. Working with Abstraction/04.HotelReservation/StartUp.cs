namespace _04.HotelReservation
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            PriceCalculator priceCalculator = new PriceCalculator(Console.ReadLine());
            Console.WriteLine(priceCalculator.CalculatePrice());
        }
    }
}
