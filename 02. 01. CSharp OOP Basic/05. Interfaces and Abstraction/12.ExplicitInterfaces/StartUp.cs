namespace _12.ExplicitInterfaces
{
    using System;
    using System.Text;

    class StartUp
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var line = input.Split();
                var name = line[0];
                var country = line[1];
                var age = int.Parse(line[2]);

                var citizen = new Citizen(name, country, age);
                sb.AppendLine(((IPerson)citizen).GetName());
                sb.AppendLine(((IResident)citizen).GetName());
            }

            Console.WriteLine(string.Join(Environment.NewLine, sb.ToString().TrimEnd()));
        }
    }
}
