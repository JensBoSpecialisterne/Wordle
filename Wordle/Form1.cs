using System.Windows.Forms;

namespace Wordle
{
    public partial class Form1 : Form
    {
        Controller controller;

        List<char> input;
        int currentGuess;

        public Form1()
        {
            KeyPreview = true;
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            InitializeComponent();
            controller = new Controller();
            input = new();
            currentGuess = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Length == 1 &&
                char.IsLetter(e.KeyCode.ToString()[0])
                && input.Count < 5
                )
            {
                input.Add(char.ToLower(e.KeyCode.ToString()[0]));
            }
            else if (e.KeyCode == Keys.Delete
                && input.Count > 0
                )
            {
                input.RemoveAt(input.Count - 1);
            }
            else if (e.KeyCode == Keys.Enter
                && input.Count == 5
                )
            {
                string guess = new string(input.ToArray());
                controller.MakeGuess(guess);
                currentGuess++;
            }
            e.Handled = false;
        }
    }
}