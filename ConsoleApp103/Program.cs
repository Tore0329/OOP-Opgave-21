using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp103
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running == true)
            {
                Console.Clear();
                Console.WriteLine("[B] - Blackjack\n[R] - Roulette\n[C] - Coinflip\n[Q] - Quit");
                Console.ForegroundColor = ConsoleColor.Black;
                var choice = Console.ReadKey();
                Console.ResetColor();
                Console.Clear();
                if (choice.KeyChar == 'B' || choice.KeyChar == 'b')
                {
                    Blackjack();
                }
                else if (choice.KeyChar == 'R' || choice.KeyChar == 'r')
                {
                    Roulette();
                }
                else if (choice.KeyChar == 'C' || choice.KeyChar == 'c')
                {
                    Coinflip();
                }
                else if (choice.KeyChar == 'Q' || choice.KeyChar == 'q')
                {
                    running = false;
                }
            }
        }

        private static void Coinflip()
        {
            string coinChoice = string.Empty;
            Coin coin = new Coin();
            string outcome = "lost";
            Console.Write("[H] - Heads\n[T] - Tails");
            while (coinChoice == string.Empty)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                var choice = Console.ReadKey();
                Console.ResetColor();

                if (choice.KeyChar == 'H' || choice.KeyChar == 'h')
                {
                    coinChoice = "Heads";
                }
                else if (choice.KeyChar == 'T' || choice.KeyChar == 't')
                {
                    coinChoice = "Tails";
                }
            }

            if (coinChoice == coin.State) outcome = "won";
            Console.Clear();
            Console.Write($"You {outcome}!\n\nOutcome: {coin.State}");
            Console.ReadKey();
        }

        private static void Roulette()
        {
            Console.Write("[N] - Number\n[C] - Color\n[S] - State (Even/Odd)");
            Console.ForegroundColor = ConsoleColor.Black;
            var choice = Console.ReadKey();
            Console.ResetColor();
            bool win = false;
            Spin spin = new Spin();
            Console.Clear();
            if (choice.KeyChar == 'N' || choice.KeyChar == 'n')
            {
                int nChoice = NChoice();

                if (nChoice == spin.Value) win = true;
            }
            else if (choice.KeyChar == 'C' || choice.KeyChar == 'c')
            {
                string cChoice = CChoice();

                if (cChoice == spin.Color) win = true;
            }
            else if (choice.KeyChar == 'S' || choice.KeyChar == 's')
            {
                string sChoice = SChoice();

                if (sChoice == spin.State) win = true;
            }
            Console.Clear();
            if (win == true)
            {
                Console.WriteLine($"You won!");
            }
            else
            {
                Console.WriteLine("You lost!");
            }

            Console.Write($"\n\n{spin.Value} {spin.State} {spin.Color}");
            Console.ReadKey();
        }

        private static string SChoice()
        {
            string sChoice = string.Empty;
            Console.Clear();
            Console.Write("[E] - Even\n[O] - Odd");

            while (sChoice == string.Empty)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                var choice = Console.ReadKey();
                Console.ResetColor();

                if (choice.KeyChar == 'E' || choice.KeyChar == 'e')
                {
                    sChoice = "Even";
                }
                else if (choice.KeyChar == 'O' || choice.KeyChar == 'o')
                {
                    sChoice = "Odd";
                }
            }

            return sChoice;
        }

        private static int NChoice()
        {
            int n = 77;

            while (n == 77)
            {
                Console.Clear();
                Console.Write("Input number (0-36): ");
                var choice = Console.ReadLine();
                if (choice.All(char.IsDigit) && int.Parse(choice) >= 0 && int.Parse(choice) <= 36)
                {
                    n = int.Parse(choice);
                }
            }
            
            return n;
        }

        private static string CChoice()
        {
            Console.Write("[R] - Red\n[B] - Black\n[G] - Green");
            string cChoice = string.Empty;

            while (cChoice == string.Empty)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                var choice = Console.ReadKey();
                Console.ResetColor();

                if (choice.KeyChar == 'R' || choice.KeyChar == 'r')
                {
                    cChoice = "Red";
                }
                else if (choice.KeyChar == 'B' || choice.KeyChar == 'b')
                {
                    cChoice = "Black";
                }
                else if (choice.KeyChar == 'G' || choice.KeyChar == 'g')
                {
                    cChoice = "Green";
                }
            }

            return cChoice;
        }

        private static void Blackjack()
        {
            List<Card> playerHand = new List<Card>();
            List<Card> dealerHand = new List<Card>();
            bool running = true;
            Console.WriteLine("[H] - Hit\n[S] - Stand\n");

            while (running == true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                var choice = Console.ReadKey();
                Console.ResetColor();
                if (choice.KeyChar == 'H' || choice.KeyChar == 'h')
                {
                    Card card = new();
                    playerHand.Add(card);
                    int count = BJCount(playerHand);

                    Console.Write($"\n{card.Type} {card.Name}\n(Total: {count})");

                    if (count >= 21) running = false;
                }
                else if (choice.KeyChar == 'S' || choice.KeyChar == 's') running = false;
            }
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Dealer dealing...");
            Thread.Sleep(2000);

            while (running == false)
            {
                Card card = new();
                dealerHand.Add(card);
                int count = BJCount(dealerHand);

                Console.Write($"\n{card.Type} {card.Name}\t(Total: {count})");

                if (count > 16) running = true;

                Thread.Sleep(2000);
            }

            Console.Clear();
            Console.SetCursorPosition(45, 6);
            Console.Write(BJOutcome(BJCount(playerHand), BJCount(dealerHand)));
            Console.SetCursorPosition(25, 10);
            Console.WriteLine($"Player Total: {BJCount(playerHand)}\t\tDealer Total: {BJCount(dealerHand)}");
            Console.ReadKey();
        }

        private static string BJOutcome(int a, int b)
        {
            string output = string.Empty;

            if (a > 21) output = "You lose!";
            else if (b > a && b < 22) output = "You lose!";
            else if (a == b) output = "You tied!";
            else output = "You win!";

            return output;
        }

        private static int BJCount(List<Card> list)
        {
            int n = 0;
            int aces = 0;

            foreach(Card card in list)
            {
                if (card.Value == 1) aces++;
                else if (card.Value > 10) n += 10;
                else n += card.Value;
            }

            for (int i = 0; i < aces; i++)
            {
                if (n < 11) n += 11;
                else n += 1;
            }

            return n;
        }
    }
}
