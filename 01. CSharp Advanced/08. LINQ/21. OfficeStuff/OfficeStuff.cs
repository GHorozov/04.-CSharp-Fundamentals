using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeStuff
{
    public class Order
    {
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }

        public Order(string companyName, string productName, int amount)
        {
            this.CompanyName = companyName;
            this.ProductName = productName;
            this.Amount = amount;
        }
    }
    class OfficeStuff
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var orders = new List<Order>();
            for (int i = 0; i < count; i++)
            {
                var order = Console.ReadLine()
                    .Trim('|')
                    .Split('-')
                    .Select(x => x.Trim())
                    .ToArray();

                orders.Add(new Order(order[0], order[2], int.Parse(order[1])));
            }

            var groupedCompanies = orders
                 .GroupBy(c => c.CompanyName) //Order company name as key and rest as values
                 .OrderBy(x => x.Key);

            foreach (var company in groupedCompanies)
            {
                Console.Write(company.Key + ": ");

                var products = company
                    .GroupBy(pr => pr.ProductName)
                    .Select(gr => new
                    {
                        PrName = gr.Key,
                        Amount = gr.Sum(x => x.Amount)
                    });
                Console.WriteLine(string.Join(", ", products.Select(x => $"{x.PrName}-{x.Amount}")));
            }


            //II-way on one line
            //orders
            //    .GroupBy(or => or.CompanyName) //Group by company name
            //    .OrderBy(x => x.Key) //Order ascending
            //    .Select(gr => gr.GroupBy(pr => pr.ProductName).Select(prg => new //Select each gr and group by productName
            //    {                                                               //make new anonymous object
            //        CompanyName = gr.Key,
            //        ProdName = prg.Key,
            //        Amount = prg.Sum(x => x.Amount)
            //    }))
            //    .ToList()            //Select each company name and take first then stringJoin  for current company product name, amount  
            //    .ForEach(list => Console.WriteLine(list.Select(x => x.CompanyName).First() + ":" + string.Join(", ", list.Select(x => $"{x.ProdName}-{x.Amount}"))));
        }
    }
}
