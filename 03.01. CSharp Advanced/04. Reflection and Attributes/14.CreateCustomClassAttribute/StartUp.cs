namespace _14.CreateCustomClassAttribute
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var attribute = (CustomAttribute)typeof(Weapon).GetCustomAttributes(true).FirstOrDefault();
            Console.WriteLine(attribute);
        }
    }
}
