using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class BlackJackHand : Hand
    {
        public int getBlackJackValue()
        {
            int value = 0; 
            bool ace = false;
            foreach (Card c in cards) {
                int cardValue = c.getValue();
                if (cardValue > 10) {
                    cardValue = 10;
                }
                else if (cardValue == 1) {
                    ace = true;
                }
                value += cardValue;
            }
            if (ace && value + 11 <= 21) {
                value += 11;
            }
            return value;
        }
    }
}
