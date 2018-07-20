namespace _03._Number_Wars
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
        private static Queue<Card> playerOneCards = new Queue<Card>();
        private static Queue<Card> playerTwoCards = new Queue<Card>();
        private const string Alphabet = "#abcdefghijklmnopqrstuvwxyz";
        private static Queue<Card> board = new Queue<Card>();
        private static bool hasWinner;

        static void Main(string[] args)
        {
            var firstPlayerCardInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var secondPlayerCardInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            playerOneCards = GetCardsFromInput(firstPlayerCardInput, playerOneCards);
            playerTwoCards = GetCardsFromInput(secondPlayerCardInput, playerTwoCards);

            var turns = 0;
            while (turns <= 1_000_000 || hasWinner == false)
            {
                if (playerOneCards.Count == 0 || playerTwoCards.Count == 0)
                {
                    hasWinner = true;
                    break;
                }
                else
                {
                    DealCards();
                    turns++;
                }
            }

            PrintResult(playerOneCards, playerTwoCards, turns);
        }

        private static void DealCards()
        {
            board.Clear();

            var playerOneCard = playerOneCards.Dequeue();
            board.Enqueue(playerOneCard);
            var playerTwoCard = playerTwoCards.Dequeue();
            board.Enqueue(playerTwoCard);

            CompareCards(playerOneCard.Digit, playerTwoCard.Digit);
        }

        private static void CompareCards(int playerOneCard, int playerTwoCard)
        {
            if (playerOneCard > playerTwoCard)
            {
                WinnerTakesCards(playerOneCards);
            }
            else if (playerOneCard < playerTwoCard)
            {
                WinnerTakesCards(playerTwoCards);
            }
            else
            {
                if (playerOneCards.Count >= 3 && playerTwoCards.Count >= 3)
                {
                    Voina();
                }
                else
                {
                    hasWinner = true;
                }
            }
        }

        private static void Voina()
        {
            var playerOneSum = 0;
            var playerTwoSum = 0;

            for (int i = 0; i < 3; i++)
            {
                playerOneSum += Alphabet.IndexOf(playerOneCards.Peek().Letter);
                board.Enqueue(playerOneCards.Dequeue());
                playerTwoSum += Alphabet.IndexOf(playerTwoCards.Peek().Letter);
                board.Enqueue(playerTwoCards.Dequeue());
            }

            CompareCards(playerOneSum, playerTwoSum);
        }

        private static void WinnerTakesCards(Queue<Card> playersCards)
        {
            foreach (var card in board.OrderByDescending(x => x.Digit).ThenByDescending(x => x.Letter))
            {
                playersCards.Enqueue(card);
            }
        }

        private static Queue<Card> GetCardsFromInput(string[] inputCards, Queue<Card> playerCards)
        {
            foreach (var input in inputCards)
            {
                var digit = int.Parse(input.Substring(0, input.Length - 1));
                var letter = input.Substring(input.Length - 1);
                playerCards.Enqueue(new Card(digit, letter));
            }

            return playerCards;
        }

        private static void PrintResult(Queue<Card> firstPlayerCards, Queue<Card> secondPlayerCards, int turns)
        {
            if (firstPlayerCards.Count > secondPlayerCards.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else if (firstPlayerCards.Count < secondPlayerCards.Count)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turns} turns");
            }

            Environment.Exit(0);
        }
    }
}
