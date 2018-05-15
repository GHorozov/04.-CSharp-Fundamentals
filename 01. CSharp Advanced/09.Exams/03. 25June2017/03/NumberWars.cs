using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberWars
{
    class NumberWars
    {
        static void Main(string[] args)
        {
            var firstPlayer = new Queue<string>(Console.ReadLine().Split(' '));
            var secondPlayer = new Queue<string>(Console.ReadLine().Split(' '));

            var turns = 0;
            while(firstPlayer.Count > 0 && secondPlayer.Count > 0 && turns < 1000000)
            {
                var firstPlayerCard = firstPlayer.Dequeue();
                var seconPlayerCard = secondPlayer.Dequeue();

                var numberFirstPlayer = int.Parse(firstPlayerCard.Substring(0, firstPlayerCard.Length - 1));
                var numberSecondPlayer = int.Parse(seconPlayerCard.Substring(0, seconPlayerCard.Length - 1));

                var letterFirstPlayer = firstPlayerCard.Substring(firstPlayerCard.Length - 2, 1);
                var letterSecondPlayer = seconPlayerCard.Substring(seconPlayerCard.Length - 2, 1);

                if (numberFirstPlayer > numberSecondPlayer || numberFirstPlayer < numberSecondPlayer)
                {
                    if(numberFirstPlayer > numberSecondPlayer)
                    {
                        firstPlayer.Enqueue(firstPlayerCard);
                        firstPlayer.Enqueue(seconPlayerCard);
                    }
                    else
                    {
                        secondPlayer.Enqueue(seconPlayerCard);
                        secondPlayer.Enqueue(firstPlayerCard);
                    }
                }
                else if(numberFirstPlayer == numberSecondPlayer)
                {
                    
                        if(firstPlayer.Count == 0 && secondPlayer.Count == 0)
                        {
                            Console.WriteLine($"Draw after {turns} turns");
                        }
                        if (firstPlayer.Count < 3)
                        {
                            Console.WriteLine($"Second player wins after {turns} turns");
                            return;
                        }
                        else if (secondPlayer.Count < 3)
                        {
                            Console.WriteLine($"First player wins after {turns} turns");
                            return;
                        }


                        //var firstList = firstPlayer.Take(3).ToList();
                        //var firstSum = ReturnSumLetters(firstList);

                        //var secondList = secondPlayer.Take(3).ToList();
                        //var secondSum = ReturnSumLetters(secondList);

                        //if (firstSum > secondSum)
                        //{
                        //    firstPlayer.Enqueue(firstPlayerCard);
                        //    firstPlayer.Enqueue(seconPlayerCard);

                        //    for (int i = 0; i < 3; i++)
                        //    {
                        //        firstPlayer.Enqueue(secondPlayer.Dequeue());
                        //    }
                        //}
                        //else if( firstSum < secondSum)
                        //{
                        //    secondPlayer.Enqueue(seconPlayerCard);
                        //    secondPlayer.Enqueue(firstPlayerCard);
                        //    for (int i = 0; i < 3; i++)
                        //    {
                        //        secondPlayer.Enqueue(firstPlayer.Dequeue());
                        //    }
                        //}
                    
                   

                }

                turns++;
            }


            Console.WriteLine($"First player wins after {turns} turns");

        }

        private static int ReturnSumLetters(List<string> firstList)
        {
            var sum = 0;
            for (int i = 0; i < firstList.Count; i++)
            {
                var letter = firstList[i].Substring(firstList[i].Length - 1);
               
                string alpha = "abcdefghijklmnopqrstuvwxyz";
                for (int j = 0; j < alpha.Length; j++)
                {
                    var alfa = alpha[j].ToString();
                    if (letter == alfa)
                    {
                        sum += j+1;break;
                    }
                }
               
            }

            return sum;
        }
    }
}
