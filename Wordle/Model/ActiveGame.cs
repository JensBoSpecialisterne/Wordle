using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.Model
{
    public  class ActiveGame
    {
        public ActiveGame()
        {
            CorrectAnswer = Library.Get();
        }
        string CorrectAnswer { get; set; }

        readonly History gameHistory = new();
        bool gameOver = false;

        public string MakeGuess(string guess)
        {
            if (!gameOver)
            {
                char result = AddGuess(guess);

                switch (result)
                {
                    case 'R':
                        return "Not in word list";
                    case 'G':
                        gameOver = true;
                        return "Game won";
                    default:
                        if (gameHistory.Length() > 5)
                        {
                            gameOver = true;
                            return "Game lost";
                        }
                        return "";
                }
            }
            return "Game over. Start new game";
        }

        public char GetColor(int input)
        {
            return gameHistory.GetColor(input);
        }

        public char AddGuess(string input)
        {
            if (!Library.Contains(input)) { return 'R'; }
            if (input.ToCharArray().Length < 5) { return 'R'; }

            Guess guess = new(input, CorrectAnswer);

            gameHistory.AddGuess(guess);

            if(guess.IsCorrect()) { return 'G'; }

            return 'B';
        }

        public string GetAnswer()
        {
            return CorrectAnswer;
        }
    }
}
