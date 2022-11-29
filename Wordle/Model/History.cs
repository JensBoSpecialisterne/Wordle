using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.Model
{
    public class History
    {
        public History()
        {
            PriorGuesses = new List<Guess>();
        }

        List<Guess> PriorGuesses { get; set; }

        public void AddGuess(Guess guess)
        {
            PriorGuesses.Add(guess);
        }

        public int Length()
        {
            return PriorGuesses.Count;
        }
    }
}
