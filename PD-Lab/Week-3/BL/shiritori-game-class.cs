using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Shiritori
    {
        public List<string> words = new List<string>();
        public bool gameOver = false;
        public List<string> Play(string word, bool check)
        {
            if (words.Contains(word))
            {
                gameOver = true;
                return new List<string>() { "Game over1"};
            }
            else if (words.Count == 0)
            {
                words.Add(word.ToLower());
                gameOver = false;
                return words;
            }
            if (check)
            {
                if (words.Last().Last() == word[0])
                {
                    words.Add(word.ToLower());
                    gameOver = false;
                }
                else
                {
                    gameOver = true;
                }
            }
            return words;
        }
        public string Restart()
        {
            // resetting the values
            words.Clear();
            gameOver = false;
            return "Game Restarted";
        }
    }
}