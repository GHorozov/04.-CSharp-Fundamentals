using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.NumberWars
{
    class Card
    {
        private int number;
        private char letter;

        public Card(int number, char letter)
        {
            this.Number = number;
            this.Letter = letter;
        }

        public int Number { get => number; set => number = value; }
        public char Letter { get => letter; set => letter = value; }
    }

    class NumberWarsTask
    {
        static void Main(string[] args)
        {
            var inputForFirstPlayer = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var inputForSecondPlayer = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();


            var firstP = new Queue<Card>();
            for (int i = 0; i < inputForFirstPlayer.Count; i++)
            {
                var firstPCard = TakeCardStr(inputForFirstPlayer[i]);
                firstP.Enqueue(firstPCard);
            }

            var secondP = new Queue<Card>();
            for (int i = 0; i < inputForFirstPlayer.Count; i++)
            {
                var secondPCard = TakeCardStr(inputForSecondPlayer[i]);
                secondP.Enqueue(secondPCard);
            }

            var winPlayer = string.Empty;
            var turns = 0;


            while (turns <= 10000 && firstP.Count != 0 && secondP.Count != 0)
            {
                turns++;
              
                var currentFirstPNumber = firstP.Peek();
                var currentSecondPNumber = secondP.Peek();

                if (currentFirstPNumber.Number != currentSecondPNumber.Number)
                {
                    if (currentFirstPNumber.Number > currentSecondPNumber.Number)
                    {
                        var secondPC = secondP.Dequeue();
                        var firstPC = firstP.Dequeue();
                        firstP.Enqueue(firstPC);
                        firstP.Enqueue(secondPC);
                    }
                    else
                    {
                        var firstPC = firstP.Dequeue();
                        var secondPC = secondP.Dequeue();
                        secondP.Enqueue(secondPC);
                        secondP.Enqueue(firstPC);
                    }
                }
                else
                {
                    var firstPListAll = new List<Card>();
                    var secondPListAll = new List<Card>();

                    firstPListAll.Add(firstP.Dequeue());
                    secondPListAll.Add(secondP.Dequeue());

                    while (firstP.Count - 3 >= 0 && secondP.Count - 3 >= 0)
                    {
                        //Take current 3 cards
                        var firstPlayer3Cards = firstP.Take(3).ToArray();
                        var secondPlayer3Cards = secondP.Take(3).ToArray();

                        var firstPList = new List<Card>();
                        var secondPList = new List<Card>();

                        //Add in current list cards
                        for (int i = 0; i < firstPlayer3Cards.Length; i++)
                        {
                            var currentCard = firstPlayer3Cards[i];
                            firstPList.Add(currentCard);
                        }
                        //Add in current list cards
                        for (int i = 0; i < secondPlayer3Cards.Length; i++)
                        {
                            var currentCard = secondPlayer3Cards[i];
                            secondPList.Add(currentCard);
                        }

                        //take sums
                        var sumLetterFirst = firstPList.Sum(x => ((int)x.Letter % 32));
                        var sumLetterSecond = secondPList.Sum(x => ((int)x.Letter % 32));


                        if (sumLetterFirst > sumLetterSecond)
                        {
                            var orderedList = secondPListAll.OrderByDescending(x => x.Number).ToList();

                            for (int i = 0; i < orderedList.Count; i++)
                            {
                                firstP.Enqueue(orderedList[i]);
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                firstP.Enqueue(secondP.Dequeue());
                            }
                        }
                        else if (sumLetterFirst < sumLetterSecond)
                        {
                            var orderedlist = firstPListAll.OrderByDescending(x => x.Number).ToList();

                            for (int i = 0; i < orderedlist.Count; i++)
                            {
                                secondP.Enqueue(orderedlist[i]);
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                secondP.Enqueue(firstP.Dequeue());
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                firstPListAll.Add(firstP.Dequeue());
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                secondPListAll.Add(secondP.Dequeue());
                            }
                        }
                    }
                }

            }

            if (firstP.Count > secondP.Count)
            {
                winPlayer = $"First player wins after {turns} turns";
            }
            else if (firstP.Count < secondP.Count)
            {
                winPlayer = $"Second player wins after {turns} turns";
            }
            else
            {
                winPlayer = $"Draw after {turns} turns";
            }

            Console.WriteLine(winPlayer);
        }

        private static Card TakeCardStr(string card)
        {
            var number = int.Parse(card.Substring(0, card.Length - 1));
            var letter = card.Substring(card.Length - 1);

            var newCard = new Card(number, char.Parse(letter));

            return newCard;
        }
    }
}
