namespace SpaceInvaders
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.p1ScoreLabel = new System.Windows.Forms.Label();
            this.p2ScoreLabel = new System.Windows.Forms.Label();
            this.highscoreLabel = new System.Windows.Forms.Label();
            this.p1Score = new System.Windows.Forms.Label();
            this.topScore = new System.Windows.Forms.Label();
            this.p2Score = new System.Windows.Forms.Label();
            this.p1LivesLabel = new System.Windows.Forms.Label();
            this.p2LivesLabel = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.earthStateLabel = new System.Windows.Forms.Label();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.easyLevelButton = new System.Windows.Forms.Button();
            this.mediumLevelButton = new System.Windows.Forms.Button();
            this.hardLevelButton = new System.Windows.Forms.Button();
            this.onePlayerButton = new System.Windows.Forms.Button();
            this.twoPlayerButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.screenDividerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Interval = 20;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // p1ScoreLabel
            // 
            this.p1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p1ScoreLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.p1ScoreLabel.Location = new System.Drawing.Point(2, -2);
            this.p1ScoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p1ScoreLabel.Name = "p1ScoreLabel";
            this.p1ScoreLabel.Size = new System.Drawing.Size(163, 31);
            this.p1ScoreLabel.TabIndex = 0;
            this.p1ScoreLabel.Text = "PLAYER (1)";
            this.p1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2ScoreLabel
            // 
            this.p2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p2ScoreLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.p2ScoreLabel.Location = new System.Drawing.Point(402, -1);
            this.p2ScoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p2ScoreLabel.Name = "p2ScoreLabel";
            this.p2ScoreLabel.Size = new System.Drawing.Size(153, 31);
            this.p2ScoreLabel.TabIndex = 1;
            this.p2ScoreLabel.Text = "PLAYER (2)";
            this.p2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // highscoreLabel
            // 
            this.highscoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.highscoreLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreLabel.ForeColor = System.Drawing.Color.White;
            this.highscoreLabel.Location = new System.Drawing.Point(218, 1);
            this.highscoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.highscoreLabel.Name = "highscoreLabel";
            this.highscoreLabel.Size = new System.Drawing.Size(120, 31);
            this.highscoreLabel.TabIndex = 2;
            this.highscoreLabel.Text = "HI-SCORE";
            this.highscoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1Score
            // 
            this.p1Score.BackColor = System.Drawing.Color.Transparent;
            this.p1Score.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Score.ForeColor = System.Drawing.Color.White;
            this.p1Score.Location = new System.Drawing.Point(7, 23);
            this.p1Score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p1Score.Name = "p1Score";
            this.p1Score.Size = new System.Drawing.Size(158, 31);
            this.p1Score.TabIndex = 3;
            this.p1Score.Text = "0000";
            this.p1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // topScore
            // 
            this.topScore.BackColor = System.Drawing.Color.Transparent;
            this.topScore.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topScore.ForeColor = System.Drawing.Color.White;
            this.topScore.Location = new System.Drawing.Point(223, 23);
            this.topScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.topScore.Name = "topScore";
            this.topScore.Size = new System.Drawing.Size(115, 31);
            this.topScore.TabIndex = 4;
            this.topScore.Text = "0000";
            this.topScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2Score
            // 
            this.p2Score.BackColor = System.Drawing.Color.Transparent;
            this.p2Score.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Score.ForeColor = System.Drawing.Color.White;
            this.p2Score.Location = new System.Drawing.Point(407, 23);
            this.p2Score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p2Score.Name = "p2Score";
            this.p2Score.Size = new System.Drawing.Size(148, 31);
            this.p2Score.TabIndex = 5;
            this.p2Score.Text = "0000";
            this.p2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1LivesLabel
            // 
            this.p1LivesLabel.BackColor = System.Drawing.Color.Transparent;
            this.p1LivesLabel.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1LivesLabel.ForeColor = System.Drawing.Color.White;
            this.p1LivesLabel.Location = new System.Drawing.Point(9, 370);
            this.p1LivesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p1LivesLabel.Name = "p1LivesLabel";
            this.p1LivesLabel.Size = new System.Drawing.Size(34, 31);
            this.p1LivesLabel.TabIndex = 6;
            this.p1LivesLabel.Text = "3";
            this.p1LivesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // p2LivesLabel
            // 
            this.p2LivesLabel.BackColor = System.Drawing.Color.Transparent;
            this.p2LivesLabel.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2LivesLabel.ForeColor = System.Drawing.Color.White;
            this.p2LivesLabel.Location = new System.Drawing.Point(511, 370);
            this.p2LivesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p2LivesLabel.Name = "p2LivesLabel";
            this.p2LivesLabel.Size = new System.Drawing.Size(32, 31);
            this.p2LivesLabel.TabIndex = 7;
            this.p2LivesLabel.Text = "3";
            this.p2LivesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // levelLabel
            // 
            this.levelLabel.BackColor = System.Drawing.Color.Transparent;
            this.levelLabel.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.Color.White;
            this.levelLabel.Location = new System.Drawing.Point(379, 371);
            this.levelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(126, 31);
            this.levelLabel.TabIndex = 8;
            this.levelLabel.Text = "LEVEL 01";
            this.levelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(151, 125);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(265, 164);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "SPACE INVADERS";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // earthStateLabel
            // 
            this.earthStateLabel.BackColor = System.Drawing.Color.Transparent;
            this.earthStateLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.earthStateLabel.ForeColor = System.Drawing.Color.White;
            this.earthStateLabel.Location = new System.Drawing.Point(137, 262);
            this.earthStateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.earthStateLabel.Name = "earthStateLabel";
            this.earthStateLabel.Size = new System.Drawing.Size(288, 31);
            this.earthStateLabel.TabIndex = 10;
            this.earthStateLabel.Text = "EARTH IS SAVED!";
            this.earthStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameOverLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.White;
            this.gameOverLabel.Location = new System.Drawing.Point(200, 119);
            this.gameOverLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(167, 31);
            this.gameOverLabel.TabIndex = 11;
            this.gameOverLabel.Text = "GAME OVER";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // easyLevelButton
            // 
            this.easyLevelButton.BackColor = System.Drawing.Color.Black;
            this.easyLevelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.easyLevelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGreen;
            this.easyLevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.easyLevelButton.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyLevelButton.ForeColor = System.Drawing.Color.White;
            this.easyLevelButton.Location = new System.Drawing.Point(403, 127);
            this.easyLevelButton.Name = "easyLevelButton";
            this.easyLevelButton.Size = new System.Drawing.Size(125, 39);
            this.easyLevelButton.TabIndex = 12;
            this.easyLevelButton.Text = "Easy";
            this.easyLevelButton.UseVisualStyleBackColor = false;
            this.easyLevelButton.Click += new System.EventHandler(this.easyLevelButton_Click);
            // 
            // mediumLevelButton
            // 
            this.mediumLevelButton.BackColor = System.Drawing.Color.Black;
            this.mediumLevelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.mediumLevelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.mediumLevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mediumLevelButton.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumLevelButton.ForeColor = System.Drawing.Color.White;
            this.mediumLevelButton.Location = new System.Drawing.Point(403, 187);
            this.mediumLevelButton.Name = "mediumLevelButton";
            this.mediumLevelButton.Size = new System.Drawing.Size(125, 39);
            this.mediumLevelButton.TabIndex = 13;
            this.mediumLevelButton.Text = "Medium";
            this.mediumLevelButton.UseVisualStyleBackColor = false;
            this.mediumLevelButton.Click += new System.EventHandler(this.mediumLevelButton_Click);
            // 
            // hardLevelButton
            // 
            this.hardLevelButton.BackColor = System.Drawing.Color.Black;
            this.hardLevelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.hardLevelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.hardLevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hardLevelButton.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardLevelButton.ForeColor = System.Drawing.Color.White;
            this.hardLevelButton.Location = new System.Drawing.Point(403, 245);
            this.hardLevelButton.Name = "hardLevelButton";
            this.hardLevelButton.Size = new System.Drawing.Size(125, 39);
            this.hardLevelButton.TabIndex = 14;
            this.hardLevelButton.Text = "Hard";
            this.hardLevelButton.UseVisualStyleBackColor = false;
            this.hardLevelButton.Click += new System.EventHandler(this.hardLevelButton_Click);
            // 
            // onePlayerButton
            // 
            this.onePlayerButton.BackColor = System.Drawing.Color.Black;
            this.onePlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.onePlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.onePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onePlayerButton.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onePlayerButton.ForeColor = System.Drawing.Color.White;
            this.onePlayerButton.Location = new System.Drawing.Point(15, 156);
            this.onePlayerButton.Name = "onePlayerButton";
            this.onePlayerButton.Size = new System.Drawing.Size(149, 40);
            this.onePlayerButton.TabIndex = 15;
            this.onePlayerButton.Text = "1 Player";
            this.onePlayerButton.UseVisualStyleBackColor = false;
            this.onePlayerButton.Click += new System.EventHandler(this.onePlayerButton_Click);
            // 
            // twoPlayerButton
            // 
            this.twoPlayerButton.BackColor = System.Drawing.Color.Black;
            this.twoPlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.twoPlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.twoPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoPlayerButton.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoPlayerButton.ForeColor = System.Drawing.Color.White;
            this.twoPlayerButton.Location = new System.Drawing.Point(15, 215);
            this.twoPlayerButton.Name = "twoPlayerButton";
            this.twoPlayerButton.Size = new System.Drawing.Size(149, 39);
            this.twoPlayerButton.TabIndex = 16;
            this.twoPlayerButton.Text = "2 Players";
            this.twoPlayerButton.UseVisualStyleBackColor = false;
            this.twoPlayerButton.Click += new System.EventHandler(this.twoPlayerButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // screenDividerLabel
            // 
            this.screenDividerLabel.BackColor = System.Drawing.Color.LawnGreen;
            this.screenDividerLabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.screenDividerLabel.Location = new System.Drawing.Point(0, 366);
            this.screenDividerLabel.Name = "screenDividerLabel";
            this.screenDividerLabel.Size = new System.Drawing.Size(550, 3);
            this.screenDividerLabel.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(550, 400);
            this.Controls.Add(this.screenDividerLabel);
            this.Controls.Add(this.twoPlayerButton);
            this.Controls.Add(this.onePlayerButton);
            this.Controls.Add(this.hardLevelButton);
            this.Controls.Add(this.mediumLevelButton);
            this.Controls.Add(this.easyLevelButton);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.earthStateLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.p2LivesLabel);
            this.Controls.Add(this.p1LivesLabel);
            this.Controls.Add(this.p2Score);
            this.Controls.Add(this.topScore);
            this.Controls.Add(this.p1Score);
            this.Controls.Add(this.highscoreLabel);
            this.Controls.Add(this.p2ScoreLabel);
            this.Controls.Add(this.p1ScoreLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Label p1ScoreLabel;
        private System.Windows.Forms.Label p2ScoreLabel;
        private System.Windows.Forms.Label highscoreLabel;
        private System.Windows.Forms.Label p1Score;
        private System.Windows.Forms.Label topScore;
        private System.Windows.Forms.Label p2Score;
        private System.Windows.Forms.Label p1LivesLabel;
        private System.Windows.Forms.Label p2LivesLabel;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label earthStateLabel;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Button easyLevelButton;
        private System.Windows.Forms.Button mediumLevelButton;
        private System.Windows.Forms.Button hardLevelButton;
        private System.Windows.Forms.Button onePlayerButton;
        private System.Windows.Forms.Button twoPlayerButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label screenDividerLabel;
    }
}

