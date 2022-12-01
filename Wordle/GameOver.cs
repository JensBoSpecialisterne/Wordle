using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle
{
    public partial class GameOver : Form
    {
        Wordle Wordle;
        public GameOver(bool won, string correctAnswer, Wordle sender)
        {
            InitializeComponent();
            if (won)
            {
                LabelGameOver.Text = "You won";
            }
            else
            {
                LabelGameOver.Text = "You lost";
            }
            Wordle = sender;
            LabelStatus.Text = correctAnswer;
        }

        private void ButtonNewGame_Click(object sender, EventArgs e)
        {
            Wordle.NewGame();
            Close();
        }
    }
}
