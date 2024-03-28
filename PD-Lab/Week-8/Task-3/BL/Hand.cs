using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Hand
    {
        protected List<Card> cards;
        public Hand()
        {
            cards = new List<Card>();
        }
        public void Clear()
        {
            cards.Clear();
        }
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        public void RemoveCard(Card card)
        {
            cards.Remove(card);
        }
        public void RemoveCard(int position)
        {
            if (position >= 0 && position < cards.Count)
            {
                cards.RemoveAt(position);
            }
        }
        public int getCardCount()
        {
            return cards.Count;
        }
        public Card getCard(int position)
        {
            return cards[position];
        }   
        public void sortByValue()
        {
            cards = cards.OrderBy(c => c.getValue()).ToList();
        }
        public void sortBySuit()
        {
            cards = cards.OrderBy(c => c.getSuit()).ToList();
        }
        public string viewCards()
        {
            string res = "";
            foreach (Card c in cards)
            {
                res += c.toString() + "\n";
            }
            return res;
        }
    }
}
