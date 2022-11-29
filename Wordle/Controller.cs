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

        public void MakeGuess(string guess)
        {
            LastResult = currentGame.MakeGuess(guess);
        }
    }
}
