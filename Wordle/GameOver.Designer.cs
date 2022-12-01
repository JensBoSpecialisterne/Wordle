namespace Wordle
{
    partial class GameOver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonNewGame = new System.Windows.Forms.Button();
            this.LabelGameOver = new System.Windows.Forms.Label();
            this.LabelCorrect = new System.Windows.Forms.Label();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonNewGame
            // 
            this.ButtonNewGame.Location = new System.Drawing.Point(12, 77);
            this.ButtonNewGame.Name = "ButtonNewGame";
            this.ButtonNewGame.Size = new System.Drawing.Size(75, 23);
            this.ButtonNewGame.TabIndex = 0;
            this.ButtonNewGame.Text = "New Game";
            this.ButtonNewGame.UseVisualStyleBackColor = true;
            this.ButtonNewGame.Click += new System.EventHandler(this.ButtonNewGame_Click);
            // 
            // LabelGameOver
            // 
            this.LabelGameOver.AutoSize = true;
            this.LabelGameOver.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelGameOver.Location = new System.Drawing.Point(32, 9);
            this.LabelGameOver.Name = "LabelGameOver";
            this.LabelGameOver.Size = new System.Drawing.Size(93, 25);
            this.LabelGameOver.TabIndex = 1;
            this.LabelGameOver.Text = "You Won";
            // 
            // LabelCorrect
            // 
            this.LabelCorrect.AutoSize = true;
            this.LabelCorrect.Location = new System.Drawing.Point(12, 34);
            this.LabelCorrect.Name = "LabelCorrect";
            this.LabelCorrect.Size = new System.Drawing.Size(125, 15);
            this.LabelCorrect.TabIndex = 2;
            this.LabelCorrect.Text = "The correct word was: ";
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelStatus.Location = new System.Drawing.Point(12, 49);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(40, 15);
            this.LabelStatus.TabIndex = 3;
            this.LabelStatus.Text = "label1";
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(144, 108);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.LabelCorrect);
            this.Controls.Add(this.LabelGameOver);
            this.Controls.Add(this.ButtonNewGame);
            this.Name = "GameOver";
            this.Text = "Game Over";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ButtonNewGame;
        private Label LabelGameOver;
        private Label LabelCorrect;
        private Label LabelStatus;
    }
}