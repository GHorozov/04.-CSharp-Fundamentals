namespace _03._1_Number_Wars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Card
    {
        public Card(int digit, string letter)
        {
            this.Digit = digit;
            this.Letter = letter;
        }

        public int Digit { get; }
        public string Letter { get; }
    }

    class NumberWars
    {
        private static Queue<Card> firstDeck = new Queue<Card>();
        private static Queue<Card> secondDeck = new Queue<Card>();


        static void Main(string[] args)
        {
            const string Alphabet = "#abcdefghijklmnopqrstuvwxyz";
            firstDeck = GetCards(firstDeck);
            secondDeck = GetCards(secondDeck);

            var HasWinner = false;
            var turns = 0;

            while (HasWinner == false && turns < 1_000_000 && firstDeck.Count > 0 && secondDeck.Count > 0)
            {
                turns++;

                var firstCard = firstDeck.Dequeue();
                var secondCard = secondDeck.Dequeue();

                if (firstCard.Digit > secondCard.Digit)
                {
                    firstDeck.Enqueue(firstCard);
                    firstDeck.Enqueue(secondCard);
                }
                else if (firstCard.Digit < secondCard.Digit)
                {
                    secondDeck.Enqueue(secondCard);
                    secondDeck.Enqueue(firstCard);
                }
                else
                {
                    var board = new List<Card>() { firstCard, secondCard };

                    while (HasWinner == false)
                    {
                        if(firstDeck.Count < 3 || secondDeck.Count < 3)
                        {
                            HasWinner = true;
                            break;
                        }

                        int firstSum = 0;
                        int secondSum = 0;

                        for (int i = 0; i < 3; i++)
                        {
                            firstSum += Alphabet.IndexOf(firstDeck.Peek().Letter);
                            secondSum += Alphabet.IndexOf(secondDeck.Peek().Letter);

                            board.Add(firstDeck.Dequeue());
                            board.Add(secondDeck.Dequeue());
                        }

                        if(firstSum > secondSum)
                        {
                            foreach (var card in board.OrderByDescending(x => x.Digit).ThenByDescending(x => x.Letter))
                            {
                                firstDeck.Enqueue(card);
                            }
                            break;
                        }
                        else if (firstSum < secondSum)
                        {
                            foreach (var card in board.OrderByDescending(x => x.Digit).ThenByDescending(x => x.Letter))
                            {
                                secondDeck.Enqueue(card);
                            }
                            break;
                        }
                    }
                }
            }

            var winner = GetWinner(firstDeck, secondDeck);
            Console.WriteLine($"{winner} after {turns} turns");

        }

        private static string GetWinner(Queue<Card> firstDeck, Queue<Card> secondDeck)
        {
            if(firstDeck.Count > secondDeck.Count)
            {
                return "First player wins";
            }
            else if(firstDeck.Count < secondDeck.Count)
            {
                return "Second player wins";
            }
            else
            {
                return "Draw";
            }
        }

        private static Queue<Card> GetCards(Queue<Card> deck)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in input)
            {
                var number = int.Parse(item.Substring(0, item.Length - 1));
                var letter = item.Substring(item.Length - 1);
                deck.Enqueue(new Card(number, letter));
            }

            return deck;
        }
    }
}
