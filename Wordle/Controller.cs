using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Model;

namespace Wordle
{
    internal class Controller
    {
        ActiveGame currentGame;
        string LastResult { get; set; }
        public Controller()
        {
            currentGame = new();
            LastResult = "";
        }

        public void NewGame()
        {
            currentGame = new();
            LastResult = "";
        }

        public Color GetColor(int input)
        {
            switch (currentGame.GetColor(input))
            {
                case 'G':
                    return Color.Green;
                case 'B':
                    return Color.Yellow;
                default:
                    return Color.Gray;
            }
        }

        public string MakeGuess(string guess)
        {
            return currentGame.MakeGuess(guess);
        }

        public string GetAnswer()
        {
            return currentGame.GetAnswer();
        }
    }
}
