using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Deck
    {
        private List<Card> cards;
        public Deck()
        {
            cards = new List<Card>();
            CreateDeck();
        }
        private void CreateDeck()
        {
            for (int suit = 1; suit <= 4; suit++) {
                for (int value = 1; value <= 13; value++) {
                    Card card = new Card(value, suit);
                    cards.Add(card);
                }
            }
        }
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int randomIndex = random.Next(cards.Count);
                Card temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }
        public int CardsLeft()
        {
            return cards.Count;
        }
        public Card DealCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}
