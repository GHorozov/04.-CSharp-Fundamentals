using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOfCards
{
    class HandsOfCards
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var nameAndCards = new Dictionary<string, HashSet<string>>();

            while (input != "JOKER")
            {
                var lineParts = input.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var playerName = lineParts[0];
                var sequance = lineParts[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (!nameAndCards.ContainsKey(playerName))
                {
                    nameAndCards[playerName] = new HashSet<string>();
                }

                for (int i = 0; i < sequance.Count(); i++)
                {
                    nameAndCards[playerName].Add(sequance[i]);
                }
                
                input = Console.ReadLine();
            }


            foreach (var entry in nameAndCards)
            {
                var name = entry.Key;
                var cards = entry.Value;

                var points = 0;
                foreach (var card in cards)
                {
                    var power = card.Substring(0, card.Length - 1);
                    var color = card.Substring(card.Length-1);

                    var cardPower = GetPower(power);
                    var cardColor = GetColor(color);

                    points += (cardPower * cardColor);
                }

                Console.WriteLine($"{name}: {points}");
            }
        }

        private static int GetColor(string color)
        {
            switch (color)
            {
                case "C":
                    return 1;
                case "D":
                    return 2;
                case "H":
                    return 3;                 
                case "S":
                    return 4;                  
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private static int GetPower(string power)
        {
            switch (power)
            {
                case "2":
                    return 2;                  
                case "3":
                    return 3;                  
                case "4":
                    return 4;                   
                case "5":
                    return 5;                  
                case "6":
                    return 6;                  
                case "7":
                    return 7;                  
                case "8":
                    return 8;                 
                case "9":
                    return 9;                  
                case "10":
                    return 10;                 
                case "J":
                    return 11;                  
                case "Q":
                    return 12;                   
                case "K":
                    return 13;                  
                case "A":
                    return 14;              
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
