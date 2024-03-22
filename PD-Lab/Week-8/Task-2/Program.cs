using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        private static int predictionStreak = 0;
        private static List<int> predictions = new List<int>();
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            deck.Shuffle();

            Card dealtCard = deck.DealCard();   
            
            // main loop
            while (deck.CardsLeft() > 0)
            {
                ScoreBoard();
                Console.WriteLine("The card is: " + dealtCard.toString());
                
                int prediction = getPrediction();

                Card nextCard = deck.DealCard();
                if (prediction == 1 && nextCard.getValue() >= dealtCard.getValue()) {
                    correctPrediction();
                }
                else if (prediction == 0 && nextCard.getValue() <= dealtCard.getValue()) {
                    correctPrediction();
                }
                else {
                    incorrectPrediction();
                    predictions.Add(predictionStreak);      // tracking all the prediction streak
                    predictionStreak = 0;
                }
                dealtCard = nextCard;
            }
            gameOverScreen();
        }
        private static int getPrediction()
        {
            int value = -1;
        TakeInputAgain:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Higher(1) or Lower(0): ");
            try {
                value = getValue();
                if (!validateInput(value)) {
                    // if the input is not 0 or 1
                    goto TakeInputAgain;
                }
            }
            catch (Exception e) {
                // if the input is not an integer
                goto TakeInputAgain;
            }
            Console.ResetColor();
            return value;
        }
        private static int getValue()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return Convert.ToInt32(Console.ReadLine());
        }
        private static bool validateInput(int value)
        {
            return value == 0 || value == 1;
        }
        private static void correctPrediction()
        {
            predictionStreak++;
        }
        private static void incorrectPrediction()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Incorrect Prediction ");
            Console.ReadLine();
            Console.ResetColor();
        }
        private static void ScoreBoard()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Current Streak: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(predictionStreak);
            Console.ResetColor();
        }
        private static void gameOverScreen()
        {
            Console.Clear();
            Console.WriteLine("---Game Over---");
            Console.WriteLine("High Score: " + getHighScore());
            Console.WriteLine("Average Score: " + getAverageScore());
            // to avoid closing the console 
            while (true)
            {
                Console.ReadLine();
            }
        }
        private static int getHighScore()
        {
            return predictions.Max();
        }
        private static float getAverageScore()
        {
            float sum = predictions.Sum();      // sum of all prediction streaks
            float count = predictions.Count();  // number of predictions
            return sum / count;
        }
    }
}
