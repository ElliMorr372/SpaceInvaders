using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Management.Instrumentation;

// Elliana Morrison: January 24th, 2023
// A simple recreation of the classic game
// Space Invaders, with aleins, up to two players,
// and lasers that can be shot

namespace SpaceInvaders
{
    public partial class Form1 : Form
    {
        //Setup all objects
        Rectangle player1 = new Rectangle(260, 335, 20, 10);
        Rectangle player2 = new Rectangle(338, 335, 20, 10);
        Rectangle safetyBase1 = new Rectangle(130, 290, 35, 30);
        Rectangle safetyBase2 = new Rectangle(210, 290, 35, 30);
        Rectangle safetyBase3 = new Rectangle(290, 290, 35, 30);
        Rectangle safetyBase4 = new Rectangle(370, 290, 35, 30);
        Rectangle player1Laser = new Rectangle(-30, -30, 2, 10);
        Rectangle player2Laser = new Rectangle(-30, -30, 2, 10);
        Rectangle alienLaser = new Rectangle(-30, -30, 2, 10);

        List<Rectangle> aliens = new List<Rectangle>();

        //Setup all integers

        //Players
        int player1Speed = 8;
        int player2Speed = 8;
        int laserSpeed = 6;

        int player1Score = 0000;
        int player2Score = 0000;
        int highscore = 0;
        int player1Lives = 3;
        int player2Lives = 3;

        //Aliens
        int alienSpeed = 5;
        int alienHeight = 15;
        int alienWidth = 15;

        //Button press bools
        bool aDown = false;
        bool dDown = false;
        bool leftDown = false;
        bool rightDown = false;
        bool wDown = false;
        bool upDown = false;

        bool p1Laser = false;
        bool p2Laser = false;
        bool aLaser = false;

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush greenBrush = new SolidBrush(Color.LawnGreen);

        string gameState = "waiting";
        string gameLevel = "waiting";

        public Form1()
        {
            InitializeComponent();
            aliens.Add(new Rectangle(165, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(185, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(205, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(225, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(245, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(265, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(285, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(305, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(325, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(345, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(365, 60, alienWidth, alienHeight));
        }

        public void GameSetup()
        {
            // set gamestate to waiting, enable game loop, and clear aliens list
            gameState = "waiting";
            gameLoop.Enabled = true;
            aliens.Clear();
            aliens.Add(new Rectangle(165, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(185, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(205, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(225, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(245, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(265, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(285, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(305, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(325, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(345, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(365, 60, alienWidth, alienHeight));
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Up:
                    upDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.Up:
                    upDown = false;
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            // move player1, only left and right
            if (aDown == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += player1Speed;
            }

            // move player2, only left and right
            if (leftDown == true && player2.X > 0)
            {
                player2.X -= player2Speed;
            }

            if (rightDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += player2Speed;
            }

            //start moving aliens from the left
            for (int i = 0; i < aliens.Count; i++)
            {
                int x = aliens[i].X + alienSpeed;
                aliens[i] = new Rectangle(x, aliens[i].Y, alienWidth, alienHeight);
            }
            
            // if they collide remove that alien, give point to player, 
            // remove that laser
            for (int i = 0; i < aliens.Count; i++)
            {
                if (aliens[i].IntersectsWith(player1Laser))
                {
                    p1Laser = false;
                    aliens.RemoveAt(i);
                    player1Score += 15;
                    p1Score.Text = $"{player1Score}";
                    break;
                }
                else if (aliens[i].IntersectsWith(player2Laser))
                {
                    p2Laser = false;
                    aliens.RemoveAt(i);
                    player2Score += 15;
                    p2Score.Text = $"{player2Score}";
                    break;
                }
            }

            //make the aliens bounce if they hit either wall
            if (aliens[aliens.Count -1].X > this.Width - alienWidth || aliens[0].X < 0)
            {
                alienSpeed = alienSpeed * -1;

                for (int j = 0; j < aliens.Count; j++)
                {
                    int y = aliens[j].Y + alienHeight + 5;
                    aliens[j] = new Rectangle(aliens[j].X, y, alienWidth, alienHeight);
                }
            }

            // check for lasers
            // player 1
            if (wDown == true && p1Laser == false)
            {
                player1Laser.X = player1.X + 10;
                player1Laser.Y = player1.Y;
                p1Laser = true;
            }

            if (p1Laser == true)
            {
                player1Laser.Y -= laserSpeed;
            }

            if (player1Laser.Y < 0)
            {
                p1Laser = false;
            }

            if (p1Laser == false)
            {
                player1Laser.X = -30;
                player1Laser.Y = -30;
            }

            // player 2
            if (upDown == true && p2Laser == false)
            {
                player2Laser.X = player2.X + 10;
                player2Laser.Y = player2.Y;
                p2Laser = true;
            }

            if (p2Laser == true)
            {
                player2Laser.Y -= laserSpeed;
            }

            if (player2Laser.Y < 0)
            {
                p2Laser = false;
            }

            if (p2Laser == false)
            {
                player2Laser.X = -30;
                player2Laser.Y = -30;
            }

            // aliens

            if (aLaser == true)
            {
                alienLaser.Y -= laserSpeed;
            }

            if (alienLaser.Y > this.Height - alienLaser.Width)
            {
                aLaser = false;
            }

            if (aLaser == false)
            {
                alienLaser.X = -30;
                alienLaser.Y = -30;
            }


            // check for player collisions with alien lasers,
            // if they collide take that player's life and reset posiiton,
            // remove that laser
            for (int i = 0; i < aliens.Count; i++)
            {
                if (player1.IntersectsWith(alienLaser))
                {
                    aLaser = false;
                    player1.X = 260;
                    player1.Y = 335;
                    player1Lives--;
                }
                else if (player2.IntersectsWith(alienLaser))
                {
                    aLaser = false;
                    player2.X = 338;
                    player2.Y = 335;
                    player2Lives--;
                }
            }

            // check for alien collisions with player lasers,


            // check for player collisions with an alien, remove
            // that alien and take a life from the player, reset player position
            for (int i = 0; i < aliens.Count; i++)
            {
                if (player1.IntersectsWith(aliens[i]))
                {
                    player1.X = 260;
                    player1.Y = 335;
                    aliens.RemoveAt(i);
                    player1Lives--;
                }
                else if (player2.IntersectsWith(aliens[i]))
                {
                    player2.X = 338;
                    player2.Y = 335;
                    aliens.RemoveAt(i);
                    player2Lives--;
                }
            }

            // check for laser collisions with the safety bases
            if (player1Laser.IntersectsWith(safetyBase1) || (player1Laser.IntersectsWith(safetyBase2))
                || (player1Laser.IntersectsWith(safetyBase3)) || (player1Laser.IntersectsWith(safetyBase4)))
            {
                p1Laser = false;
            }
            else if (player2Laser.IntersectsWith(safetyBase1) || (player2Laser.IntersectsWith(safetyBase2))
                || (player2Laser.IntersectsWith(safetyBase3)) || (player2Laser.IntersectsWith(safetyBase4)))
            {
                p2Laser = false;
            }
            else if (alienLaser.IntersectsWith(safetyBase1) || (alienLaser.IntersectsWith(safetyBase2))
                || (alienLaser.IntersectsWith(safetyBase3)) || (player1Laser.IntersectsWith(safetyBase4)))
            {
                aLaser = false;
            }
            

            //check if player lives or all aliens are all gone
            if (player1Lives == 0 && player2Lives == 0)
            {
                gameState = "earthLost";
            }
            else if (aliens.Count == 0)
            {
                gameState = "earthSaved";
            }

            Refresh();
        }

        private void onePlayerButton_Click(object sender, EventArgs e)
        {
            gameState = "1Player";
            gameLoop.Enabled = true;
            this.Focus();
        }

        private void twoPlayerButton_Click(object sender, EventArgs e)
        {
            gameState = "2Player";
            gameLoop.Enabled = true;
            player1.X = 178;
            this.Focus();
        }

        private void easyLevelButton_Click(object sender, EventArgs e)
        {
            gameLevel = "easy";
            gameLoop.Enabled = true;
            this.Focus();
        }

        private void mediumLevelButton_Click(object sender, EventArgs e)
        {
            gameLevel = "medium";
            gameLoop.Enabled = true;
            this.Focus();
        }
        private void hardLevelButton_Click(object sender, EventArgs e)
        {
            gameLevel = "hard";
            gameLoop.Enabled = true;
            this.Focus();
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            GameSetup();
            this.Focus();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                //Reset variables and titles
                player1Score = 0000;
                player2Score = 0000;
                p1Score.Text = "0000";
                p2Score.Text = "0000";
                titleLabel.Text = "SPACE INVADERS";
                gameOverLabel.Text = "";
                earthStateLabel.Text = "";

                //Make buttons visable and enabled
                easyLevelButton.Visible = true;
                mediumLevelButton.Visible = true;
                hardLevelButton.Visible = true;
                onePlayerButton.Visible = true;
                twoPlayerButton.Visible = true;
                playAgainButton.Visible = false;

                easyLevelButton.Enabled = true;
                mediumLevelButton.Enabled = true;
                hardLevelButton.Enabled = true;
                onePlayerButton.Enabled = true;
                twoPlayerButton.Enabled = true;
                playAgainButton.Enabled = false;
            }

            else if (gameState == "1Player" && gameLevel == "easy")
            {
                titleLabel.Text = "";
                gameOverLabel.Text = "";
                earthStateLabel.Text = "";
                easyLevelButton.Visible = false;
                mediumLevelButton.Visible = false;
                hardLevelButton.Visible = false;
                onePlayerButton.Visible = false;
                twoPlayerButton.Visible = false;

                easyLevelButton.Enabled = false;
                mediumLevelButton.Enabled = false;
                hardLevelButton.Enabled = false;
                onePlayerButton.Enabled = false;
                twoPlayerButton.Enabled = false;

                //draw player 1
                e.Graphics.FillRectangle(greenBrush, player1);

                //draw safety bases
                e.Graphics.FillRectangle(greenBrush, safetyBase1);
                e.Graphics.FillRectangle(greenBrush, safetyBase2);
                e.Graphics.FillRectangle(greenBrush, safetyBase3);
                e.Graphics.FillRectangle(greenBrush, safetyBase4);

                //draw aliens, 2 lines
                for (int i = 0; i < aliens.Count; i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, aliens[i]);
                }

                //draw player lasers
                if (p1Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player1Laser);
                }
                else if (aLaser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, alienLaser);
                }
            }
            else if (gameState == "1Player" && gameLevel == "medium")
            {
                titleLabel.Text = "";
                gameOverLabel.Text = "";
                earthStateLabel.Text = "";
                easyLevelButton.Visible = false;
                mediumLevelButton.Visible = false;
                hardLevelButton.Visible = false;
                onePlayerButton.Visible = false;
                twoPlayerButton.Visible = false;

                easyLevelButton.Enabled = false;
                mediumLevelButton.Enabled = false;
                hardLevelButton.Enabled = false;
                onePlayerButton.Enabled = false;
                twoPlayerButton.Enabled = false;

                //draw player 1
                e.Graphics.FillRectangle(greenBrush, player1);

                //draw safety bases
                e.Graphics.FillRectangle(greenBrush, safetyBase1);
                e.Graphics.FillRectangle(greenBrush, safetyBase2);
                e.Graphics.FillRectangle(greenBrush, safetyBase3);
                e.Graphics.FillRectangle(greenBrush, safetyBase4);

                //draw aliens, 3 lines

                //draw player1 laser
                if (p1Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player1Laser);
                }

                //draw alien laser
                if (aLaser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, alienLaser);
                }
            }
            else if (gameState == "1Player" && gameLevel == "hard")
            {
                titleLabel.Text = "";
                gameOverLabel.Text = "";
                earthStateLabel.Text = "";
                easyLevelButton.Visible = false;
                mediumLevelButton.Visible = false;
                hardLevelButton.Visible = false;
                onePlayerButton.Visible = false;
                twoPlayerButton.Visible = false;

                easyLevelButton.Enabled = false;
                mediumLevelButton.Enabled = false;
                hardLevelButton.Enabled = false;
                onePlayerButton.Enabled = false;
                twoPlayerButton.Enabled = false;

                //draw player 1
                e.Graphics.FillRectangle(greenBrush, player1);

                //draw safety bases
                e.Graphics.FillRectangle(greenBrush, safetyBase1);
                e.Graphics.FillRectangle(greenBrush, safetyBase2);
                e.Graphics.FillRectangle(greenBrush, safetyBase3);
                e.Graphics.FillRectangle(greenBrush, safetyBase4);

                //draw aliens, 5 lines

                //draw player1 laser
                if (p1Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player1Laser);
                }

                //draw alien laser
                if (aLaser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, alienLaser);
                }
            }
            else if (gameState == "2Player" && gameLevel == "easy")
            {
                titleLabel.Text = "";
                gameOverLabel.Text = "";
                earthStateLabel.Text = "";
                easyLevelButton.Visible = false;
                mediumLevelButton.Visible = false;
                hardLevelButton.Visible = false;
                onePlayerButton.Visible = false;
                twoPlayerButton.Visible = false;

                easyLevelButton.Enabled = false;
                mediumLevelButton.Enabled = false;
                hardLevelButton.Enabled = false;
                onePlayerButton.Enabled = false;
                twoPlayerButton.Enabled = false;

                //draw player 1 and 2
                e.Graphics.FillRectangle(greenBrush, player1);
                e.Graphics.FillRectangle(greenBrush, player2);

                //draw safety bases
                e.Graphics.FillRectangle(greenBrush, safetyBase1);
                e.Graphics.FillRectangle(greenBrush, safetyBase2);
                e.Graphics.FillRectangle(greenBrush, safetyBase3);
                e.Graphics.FillRectangle(greenBrush, safetyBase4);

                //draw aliens, 2 lines

                //draw player1 laser
                if (p1Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player1Laser);
                }
                //draw player2 laser
                if (p2Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player2Laser);
                }

                //draw alien laser
                if (aLaser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, alienLaser);
                }
            }
            else if (gameState == "2Player" && gameLevel == "medium")
            {
                titleLabel.Text = "";
                gameOverLabel.Text = "";
                earthStateLabel.Text = "";
                easyLevelButton.Visible = false;
                mediumLevelButton.Visible = false;
                hardLevelButton.Visible = false;
                onePlayerButton.Visible = false;
                twoPlayerButton.Visible = false;

                easyLevelButton.Enabled = false;
                mediumLevelButton.Enabled = false;
                hardLevelButton.Enabled = false;
                onePlayerButton.Enabled = false;
                twoPlayerButton.Enabled = false;

                //draw player 1 and 2
                e.Graphics.FillRectangle(greenBrush, player1);
                e.Graphics.FillRectangle(greenBrush, player2);

                //draw safety bases
                e.Graphics.FillRectangle(greenBrush, safetyBase1);
                e.Graphics.FillRectangle(greenBrush, safetyBase2);
                e.Graphics.FillRectangle(greenBrush, safetyBase3);
                e.Graphics.FillRectangle(greenBrush, safetyBase4);

                //draw aliens, 3 lines

                //draw player1 laser
                if (p1Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player1Laser);
                }
                //draw player2 laser
                if (p2Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player2Laser);
                }

                //draw alien laser
                if (aLaser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, alienLaser);
                }
            }
            else if (gameState == "2Player" && gameLevel == "hard")
            {
                titleLabel.Text = "";
                gameOverLabel.Text = "";
                earthStateLabel.Text = "";
                easyLevelButton.Visible = false;
                mediumLevelButton.Visible = false;
                hardLevelButton.Visible = false;
                onePlayerButton.Visible = false;
                twoPlayerButton.Visible = false;

                easyLevelButton.Enabled = false;
                mediumLevelButton.Enabled = false;
                hardLevelButton.Enabled = false;
                onePlayerButton.Enabled = false;
                twoPlayerButton.Enabled = false;

                //draw player 1 and 2
                e.Graphics.FillRectangle(greenBrush, player1);
                e.Graphics.FillRectangle(greenBrush, player2);

                //draw safety bases
                e.Graphics.FillRectangle(greenBrush, safetyBase1);
                e.Graphics.FillRectangle(greenBrush, safetyBase2);
                e.Graphics.FillRectangle(greenBrush, safetyBase3);
                e.Graphics.FillRectangle(greenBrush, safetyBase4);

                //draw aliens, 5 lines

                //draw player1 laser
                if (p1Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player1Laser);
                }
                //draw player2 laser
                if (p2Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player2Laser);
                }
                //draw alien laser
                if (aLaser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, alienLaser);
                }
            }
            else if (gameState == "earthSaved")
            {
                easyLevelButton.Visible = false;
                mediumLevelButton.Visible = false;
                hardLevelButton.Visible = false;
                onePlayerButton.Visible = false;
                twoPlayerButton.Visible = false;
                playAgainButton.Visible = true;

                easyLevelButton.Enabled = false;
                mediumLevelButton.Enabled = false;
                hardLevelButton.Enabled = false;
                onePlayerButton.Enabled = false;
                twoPlayerButton.Enabled = false;
                playAgainButton.Enabled = true;

                gameLoop.Enabled = false;
                titleLabel.Text = "CONGRATULATIONS!";
                gameOverLabel.Text = "GAME OVER.";
                earthStateLabel.Text = "EARTH WAS SAVED!";
            }
            else if (gameState == "earthLost")
            {
                easyLevelButton.Visible = false;
                mediumLevelButton.Visible = false;
                hardLevelButton.Visible = false;
                onePlayerButton.Visible = false;
                twoPlayerButton.Visible = false;
                playAgainButton.Visible = true;

                easyLevelButton.Enabled = false;
                mediumLevelButton.Enabled = false;
                hardLevelButton.Enabled = false;
                onePlayerButton.Enabled = false;
                twoPlayerButton.Enabled = false;
                playAgainButton.Enabled = true;

                gameLoop.Enabled = false;
                titleLabel.Text = "YOU LOSE.";
                gameOverLabel.Text = "GAME OVER.";
                earthStateLabel.Text = "EARTH WAS LOST.";

            }
        }
    }
}
