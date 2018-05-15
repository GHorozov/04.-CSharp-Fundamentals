using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupByGroup
{
    public class Person
    {
        public string Name { get; set; }
        public int Group { get; set; }
    }
    class GroupByGroup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var list = new List<Person>();
            while (input != "END")
            {
                var line = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var newStudent = new Person
                {
                    Name = line[0] +" " + line[1],
                    Group = int.Parse(line[2]),    
                };
                list.Add(newStudent);
                input = Console.ReadLine();
            }

            var grouped = list
                 .GroupBy(g => g.Group) //Make each group key and for value add coresponding name
                 .OrderBy(g => g.Key); //Order group in ascending order 

            foreach (var group in grouped)
            {
                Console.Write(group.Key + " - ");
                var sb = new StringBuilder();
                foreach (var person in group)
                {
                    sb.Append(person.Name).Append(", ");
                }
                sb.Length -= 2; //remove last 2 symbols from stringBulder
                Console.WriteLine(sb);
            }


            //II-way with anonymous object
            //list
            //    .GroupBy(g => g.Group,
            //    g => g.Name,
            //    (gr, n) => new
            //    {
            //        GroupN = gr,
            //        NameN = n
            //    })
            //    .OrderBy(g => g.GroupN)
            //    .ToList()
            //    .ForEach(x => Console.WriteLine($"{x.GroupN} - {string.Join(", ", x.NameN)}"));
        }
    }
}
