using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.Model
{
    public class Guess
    {
        public Guess(string input, string correct)
        {
            GuessString = input;
            letters = input.ToCharArray();
            this.correct = correct.ToCharArray();

            SetStatus();
        }

        string GuessString {get; set;}
        readonly char[] letters = new char[5];
        readonly char[] correct = new char[5];

        // RGB used to indicate presence of the letter.
        // "R" as "Red" is equivalent to grey, meaning the letter isn't present.
        // "G" as "Green" indicates the letter is in the correct spot, same as it does in the GUI.
        // "B" as "Blue" indicates the letter is the word, but the wrong spot.
        char[] status = new char[5];

        public string GetString()
        {
            return GuessString;
        }

        internal void SetStatus()
        {
            List<char> listCorrect = correct.ToList();

            for(int i = 0; i < 5; i++)
            {
                if ( letters[i] == correct[i] ) 
                { 
                    status[i] = 'G'; 
                    listCorrect[i] = '!'; 
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (listCorrect[i] == '!')
                {

                }
                else if (listCorrect.Contains(letters[i])) 
                { 
                    status[i] = 'B';
                    listCorrect.Remove(letters[i]);
                }
                else { status[i] = 'R'; }
            }
        }

        public bool IsCorrect()
        {
            return letters == correct;
        }
    }
}
