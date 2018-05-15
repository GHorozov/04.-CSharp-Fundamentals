using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GreedyTimes
{
    class GreedyTimesTask
    {
        static void Main(string[] args)
        {
            var capacity = long.Parse(Console.ReadLine());
            var items = Console.ReadLine().Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, List<long>>>();

            var cashSum = 0L;
            var gemSum = 0L;
            var goldSum = 0L;

            for (int i = 0; i < items.Length; i += 2)
            {
                var currentItem = items[i];
                var amount = long.Parse(items[i + 1]);


                if (currentItem.Length == 3)//cash
                {
                    cashSum += amount;

                    if (gemSum >= cashSum)
                    {
                        if (capacity >= (cashSum + gemSum + goldSum))
                        {
                            if (!bag.ContainsKey("Cash"))
                            {
                                bag.Add("Cash", new Dictionary<string, List<long>>());
                            }
                            if (!bag["Cash"].ContainsKey(currentItem))
                            {
                                bag["Cash"][currentItem] = new List<long>();
                            }

                            bag["Cash"][currentItem].Add(amount);
                        }
                    }
                    else
                    {
                        cashSum -= amount;
                    }

                }
                else if (currentItem.Equals("Gold", StringComparison.InvariantCultureIgnoreCase))//gold
                {
                    goldSum += amount;

                    if (capacity >= (cashSum + gemSum + goldSum))
                    {

                        if (!bag.ContainsKey("Gold"))
                        {
                            bag.Add("Gold", new Dictionary<string, List<long>>());
                        }
                        if (!bag["Gold"].ContainsKey(currentItem))
                        {
                            bag["Gold"][currentItem] = new List<long>();
                        }

                        bag["Gold"][currentItem].Add(amount);
                    }
                    else
                    {
                        goldSum -= amount;
                    }
                }
                else if (currentItem.EndsWith("Gem", StringComparison.InvariantCultureIgnoreCase) && currentItem.Length >= 4)//gem
                {
                    gemSum += amount;


                    if (goldSum >= gemSum)
                    {
                        if (capacity >= (cashSum + gemSum + goldSum))
                        {

                            if (!bag.ContainsKey("Gem"))
                            {
                                bag.Add("Gem", new Dictionary<string, List<long>>());
                            }
                            if (!bag["Gem"].ContainsKey(currentItem))
                            {
                                bag["Gem"][currentItem] = new List<long>();
                            }

                            bag["Gem"][currentItem].Add(amount);
                        }
                    }
                    else
                    {
                        gemSum -= amount;
                    }
                }
            }

            foreach (var item in bag.OrderByDescending(x => x.Value.Sum(s => s.Value.Sum())))
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Sum(x => x.Value.Sum())}");

                foreach (var pair in item.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{pair.Key} - {pair.Value.Sum()}");
                }
            }
        }
    }
}
