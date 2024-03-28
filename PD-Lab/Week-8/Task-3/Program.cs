using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp3
{
    internal class Program
    {
        private const int HIT = 0;
        private const int BlackJack = 21;
        private const int DEALER_HIT_THRESHOLD = 17;

        private static bool DEALER_WIN = false;
        private static bool PLAYER_WIN = false;
        private static Deck deck = new Deck();
        static void Main(string[] args)
        {
            BlackJackHand player = new BlackJackHand();
            BlackJackHand dealer = new BlackJackHand();

            deck.Shuffle();

            player.AddCard(getCard());

            Card dealerCardToShow = getCard();
            dealer.AddCard(dealerCardToShow);

            player.AddCard(getCard());
            dealer.AddCard(getCard());
            if (getHandValue(player) == 21)
            {
                Console.WriteLine("Player Wins!!!");
                goto end;
            }
            if (getHandValue(dealer) == 21)
            {
                Console.WriteLine("Dealer Wins!!!");
                goto end;
            }
            while (true)
            {
                Console.WriteLine($"Dealer Card: {dealerCardToShow.toString()}");
                Console.WriteLine("Player Turn");
                Console.WriteLine($"Current Hand:\n{player.viewCards()}");

                int choice = getInput();

                if (choice == HIT)
                {
                    player.AddCard(getCard());
                    if (getHandValue(player) > 21)
                    {
                        Console.WriteLine("Player Bust");
                        Console.WriteLine("Dealer Wins!!!");
                        goto end;
                    }
                }
                // player stands
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Dealer Turn");
                Console.WriteLine($"Current Hand:\n{dealer.viewCards()}");

                if (getHandValue(dealer) < 17)
                {
                    // dealer hits if hand value is less than 17
                    dealer.AddCard(getCard());
                    if (getHandValue(dealer) > 21)
                    {
                        Console.WriteLine("Dealer Bust");
                        Console.WriteLine("Player Wins!!!");
                        goto end;
                    }
                }
                else
                {
                    break;
                }
            }
            if (getHandValue(dealer) > getHandValue(player))
            {
                Console.WriteLine("Dealer Wins!!!");
            }
            else if (getHandValue(dealer) == getHandValue(player))
            {
                Console.WriteLine("Draw");
            }
            else
            {
                Console.WriteLine("Player Wins!!!");
            }
        end:
            Console.ReadKey();
        }
        private static bool isBust(BlackJackHand hand)
        {
            if (getHandValue(hand) > 21) {
                return true;
            }
            return false;
        }
        private static void DealCard(BlackJackHand hand)
        {
            hand.AddCard(getCard());
        }
        private static int getHandValue(BlackJackHand hand)
        {
            return hand.getBlackJackValue();
        }
        private static Card getCard()
        {
            return deck.DealCard();
        }
        private static int getInput()
        {
            Console.Write("Hit(0) or Stand(1): ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
