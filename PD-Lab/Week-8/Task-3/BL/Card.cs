using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Card
    {
        private int value;
        private int suit;
        public Card(int value, int suit)
        {
            this.value = value;
            this.suit = suit;
        }
        public string toString()
        {
            return $"{getValueAsString()} of {getSuitAsString()}";
        }
        public string getSuitAsString()
        {
            string suitString = "";
            switch (suit)
            {
                case 1:
                    suitString = "Clubs";
                    break;
                case 2:
                    suitString = "Diamonds";
                    break;
                case 3:
                    suitString = "Spades";
                    break;
                case 4:
                    suitString = "Hearts";
                    break;
                default:
                    suitString = suit.ToString();
                    break;
            }
            return suitString;
        }
        public string getValueAsString()
        {
            string valueString = "";
            switch (value)
            {
                case 1:
                    valueString = "Ace";
                    break;
                case 11:
                    valueString = "Jack";
                    break;
                case 12:
                    valueString = "Queen";
                    break;
                case 13:
                    valueString = "King";
                    break;
                default:
                    valueString = value.ToString();   // 2-10 values
                    break;
            }
            return valueString;
        }
        public int getValue()
        {
            return value;
        }
        public int getSuit()
        {
            return suit;
        }
    }
}
