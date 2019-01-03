namespace _06.Telephony
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new Smartphone();

            var numbers = Console.ReadLine().Split();
            foreach (var number in numbers)
            {
                if (number.All(char.IsDigit))
                {
                    Console.WriteLine(phone.Call(number));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            var addresses = Console.ReadLine().Split();
            foreach (var address in addresses)
            {
                if(address.Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine(phone.Browse(address));
                }
            }
        }
    }
}
