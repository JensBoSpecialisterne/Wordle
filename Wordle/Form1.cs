using System.Windows.Forms;

namespace Wordle
{
    public partial class Form1 : Form
    {
        Controller controller;

        List<char> input;
        int currentLetter;
        int currentGuess;

        readonly int wordLength = 5;
        readonly int maxGuess = 6;
        readonly int labelSize = 52;
        readonly int labelDistance = 6;
        readonly int startPosition = 12;

        Label[,] grid;
        Label statusLabel;

        public Form1()
        {
            KeyPreview = true;
            KeyDown += new KeyEventHandler(Form1_KeyDown);

            InitializeComponent();

            controller = new Controller();
            input = new();
            currentGuess = 0;
            currentLetter = 0;
            grid = new Label[wordLength, maxGuess];

            statusLabel = new()
            {
                Name = "statusLabel",
                Height = 13,
                Width = 105,
                MinimumSize = new Size(105, 13),
                Text = "",
                BackColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                UseCompatibleTextRendering = true,
                AutoSize = false,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point),
                ImageAlign = ContentAlignment.TopCenter,
                Location = new Point(103, 25),
            };
            Controls.Add(statusLabel);
            statusLabel.BringToFront();
            statusLabel.Hide();

            for (int col = 0; col < wordLength; col++)
            {
                for (int row = 0; row < maxGuess; row++)
                {
                    Label label = new()
                    {
                        Name = "label" + col + row,
                        Height = labelSize,
                        Width = labelSize,
                        MinimumSize = new Size(labelSize, labelSize),
                        Text = ""
                    };
                    grid[col, row] = label;
                    grid[col, row].BackColor = Color.White;
                    grid[col, row].BorderStyle = BorderStyle.FixedSingle;
                    grid[col, row].Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
                    grid[col, row].ForeColor = Color.Black;
                    grid[col, row].ImageAlign = ContentAlignment.TopCenter;
                    grid[col, row].Location = new Point(startPosition + (labelSize + labelDistance) * col, startPosition + (labelSize + labelDistance) * row);
                    grid[col, row].TextAlign = ContentAlignment.MiddleCenter;
                    grid[col, row].UseCompatibleTextRendering = true;
                    grid[col, row].AutoSize = false;
                    Controls.Add(grid[col, row]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            HideStatus();
            if (currentGuess < 6)
            {
                if (e.KeyCode.ToString().Length == 1 &&
                    char.IsLetter(e.KeyCode.ToString()[0])
                    && input.Count < 5
                    )
                {
                    input.Add(char.ToLower(e.KeyCode.ToString()[0]));
                    grid[currentLetter, currentGuess].Text = e.KeyCode.ToString().ToUpper();
                    currentLetter++;
                }
                else if (e.KeyCode == Keys.Back
                    && input.Count > 0
                    )
                {
                    input.RemoveAt(input.Count - 1);
                    grid[currentLetter - 1, currentGuess].Text = "";
                    currentLetter--;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (input.Count < 5)
                    {
                        ShowStatus("Not enough letters");
                    }
                    else
                    {
                        string guess = new(input.ToArray());
                        string result = controller.MakeGuess(guess);
                        switch (result)
                        {
                            case "Not in word list":
                                ShowStatus("Not in word list");
                                break;
                            case "Game won":
                                CorrectInput();
                                break;
                            case "Game lost":
                                break;
                            case "":
                                CorrectInput();
                                break;
                        }
                    }
                }
            }
            e.Handled = false;
        }

        private void CorrectInput()
        {
            for (int i = 0; i < 5; i++)
            {
                grid[i, currentGuess].BackColor = controller.GetColor(i);
            }
            currentGuess++;
            currentLetter = 0;
            input.Clear();
        }

        private void ShowStatus(string input)
        {
            statusLabel.Text = input;
            statusLabel.Show();
        }

        private void HideStatus()
        {
            statusLabel.Hide();
        }
    }
}