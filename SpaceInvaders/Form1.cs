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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Reflection.Emit;

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

        int player1Score = 0;
        int player2Score = 0;
        int highscore = 0;
        int player1Lives = 3;
        int player2Lives = 3;

        //Aliens
        int alienSpeed = 4;
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

        // Setup random generator, brushes, and gamestate strings
        Random randGen = new Random();
        int randValue = 0;

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush greenBrush = new SolidBrush(Color.LawnGreen);

        string gameState = "waiting";
        string gameLevel = "waiting";

        public Form1()
        {
            InitializeComponent();
            //Clear titles
            p1ScoreLabel.Text = "00";
            p2ScoreLabel.Text = "00";
            titleLabel.Text = "SPACE INVADERS";
            gameOverLabel.Text = "";
            earthStateLabel.Text = "";
            p2LivesLabel.Text = "";
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

            //Reset variables and titles
            player1Score = 0;
            player2Score = 0;
            player1Lives = 3;
            player2Lives = 3;

            p1ScoreLabel.Text = "00";
            p2ScoreLabel.Text = "00";
            titleLabel.Text = "SPACE INVADERS";
            gameOverLabel.Text = "";
            earthStateLabel.Text = "";
            p2LivesLabel.Text = "";

            //Reset all aliens to list
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

            // Reset safety bases
            safetyBase1.X = 130;
            safetyBase1.Y = 290;
            safetyBase2.X = 210;
            safetyBase2.Y = 290;
            safetyBase3.X = 290;
            safetyBase3.Y = 290;
            safetyBase4.X = 370;
            safetyBase4.Y = 290;

            // Reset player positions
            player1.X = 260;
            player1.Y = 335;
            player2.X = 338;
            player2.Y = 335;

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

            ////change alien speed based on gameLevel - didn't have time to figure out the problems with this alien code:
            //if (gameLevel == "easy")
            //{
            //    alienSpeed = 2;
            //}
            //else if (gameLevel == "medium")
            //{
            //    alienSpeed = 4;
            //}
            //else if (gameLevel == "hard")
            //{
            //    alienSpeed = 8;
            //}

            //make the aliens reverse direction and move down if an alien on either end hits a wall
            if (aliens.Count > 0)
            {
                if (aliens[aliens.Count - 1].X > this.Width - alienWidth || aliens[0].X < 0)
                {
                    alienSpeed = alienSpeed * -1;

                    for (int j = 0; j < aliens.Count; j++)
                    {
                        int y = aliens[j].Y + alienHeight + 5;
                        aliens[j] = new Rectangle(aliens[j].X, y, alienWidth, alienHeight);
                    }
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

            if(p2Laser == false)
            {
                player2Laser.X = -30;
                player2Laser.Y = -30;
            }

            // aliens - didn't get enough time to figure out the problems with this alien laser code:
            //randValue = randGen.Next(1, 101);

            //if (gameLevel == "easy") //shoot alien lasers not that often
            //{
            //    if (aLaser == false || randValue < 11)
            //    {
            //        alienLaser.X = aliens[0].X + 7;
            //        alienLaser.Y = aliens[0].Y + 15;
            //        aLaser = true;
            //    }
            //}
            //else if (gameLevel == "medium") // shoot alien lasers more often
            //{
            //    if (aLaser == false || randValue < 21)
            //    {
            //        alienLaser.X = aliens[0].X + 7;
            //        alienLaser.Y = aliens[0].Y + 15;
            //        aLaser = true;
            //    }
            //}
            //else if (gameLevel == "hard") // shoot alien lasers really often
            //{
            //    if (aLaser == false || randValue < 41)
            //    {
            //        alienLaser.X = aliens[0].X + 7;
            //        alienLaser.Y = aliens[0].Y + 15;
            //        aLaser = true;
            //    }
            //}

            //if (aLaser == true)
            //{
            //    alienLaser.Y = laserSpeed + 5;
            //}

            //if (alienLaser.Y > this.Height - alienLaser.Height)
            //{
            //    aLaser = false;
            //}

            //if (aLaser == false)
            //{
            //    alienLaser.X = -50;
            //    alienLaser.Y = -50;
            //}


            // Check for alien collisions with player lasers
            // if they collide remove that alien, give point to player, 
            // remove that laser
            for (int i = 0; i < aliens.Count; i++)
            {
                if (aliens[i].IntersectsWith(player1Laser))
                {
                    p1Laser = false;
                    aliens.RemoveAt(i);
                    player1Score += 15;
                    p1ScoreLabel.Text = $"{player1Score}";
                    break;
                }
                else if (aliens[i].IntersectsWith(player2Laser))
                {
                    p2Laser = false;
                    aliens.RemoveAt(i);
                    player2Score += 15;
                    p2ScoreLabel.Text = $"{player2Score}";
                    break;
                }
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
                    p1LivesLabel.Text = "player1Lives";
                }
                else if (player2.IntersectsWith(alienLaser))
                {
                    aLaser = false;
                    player2.X = 338;
                    player2.Y = 335;
                    player2Lives--;
                    p1LivesLabel.Text = "player1Lives";
                }
            }

            //check if player lives or all aliens are all gone
            if (gameState == "1Player" && player1Lives == 0)
            {
                gameState = "earthLost";
            }
            else if (gameState == "2Player" && player1Lives == 0 && player2Lives == 0)
            {
                gameState = "earthLost";
            }
            else if (aliens.Count == 0)
            {
                gameState = "earthSaved";
            }

            // check for player collisions with an alien, remove
            // that alien and take a life from the player, reset player position
            for (int i = 0; i < aliens.Count; i++)
            {
                if (player1.IntersectsWith(aliens[i]))
                {
                    if (gameState == "1Player")
                    {
                        player1.X = 260;
                        player1.Y = 335;
                        aliens.RemoveAt(i);
                        player1Lives--;
                        p1LivesLabel.Text = "player1Lives";
                    }
                    else if (gameState == "2Player")
                    {
                        player1.X = 178;
                        player1.Y = 335;
                        aliens.RemoveAt(i);
                        player1Lives--;
                        p1LivesLabel.Text = "player2Lives";
                    }
                }
                else if (player2.IntersectsWith(aliens[i]))
                {
                    player2.X = 338;
                    player2.Y = 335;
                    aliens.RemoveAt(i);
                    player2Lives--;
                }
            }

            // check for alien collisions with safety bases, if collision occures remove safety base
            for (int i = 0; i < aliens.Count; i++)
            {
                if (aliens[i].IntersectsWith(safetyBase1))
                {
                    aliens.RemoveAt(i);
                    safetyBase1.X = -50;
                    safetyBase1.Y = -50;
                }
                else if (aliens[i].IntersectsWith(safetyBase2))
                {
                    aliens.RemoveAt(i);
                    safetyBase2.X = -50;
                    safetyBase2.Y = -50;
                }
                else if (aliens[i].IntersectsWith(safetyBase3))
                {
                    aliens.RemoveAt(i);
                    safetyBase3.X = -50;
                    safetyBase3.Y = -50;
                }
                else if (aliens[i].IntersectsWith(safetyBase4))
                {
                    aliens.RemoveAt(i);
                    safetyBase4.X = -50;
                    safetyBase4.Y = -50;
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
                || (alienLaser.IntersectsWith(safetyBase3)) || (alienLaser.IntersectsWith(safetyBase4)))
            {
                aLaser = false;
            }
            
            Refresh();
        }

        private void onePlayerButton_Click(object sender, EventArgs e)
        {
            onePlayerButton.BackColor = Color.Teal;
            twoPlayerButton.BackColor = Color.Black;
            easyLevelButton.BackColor = Color.Black;
            mediumLevelButton.BackColor = Color.Black;
            hardLevelButton.BackColor = Color.Black;
            playAgainButton.BackColor = Color.Black;

            gameState = "1Player";
            gameLoop.Enabled = true;
            this.Focus();
        }

        private void twoPlayerButton_Click(object sender, EventArgs e)
        {
            onePlayerButton.BackColor = Color.Black;
            twoPlayerButton.BackColor = Color.DodgerBlue;
            easyLevelButton.BackColor = Color.Black;
            mediumLevelButton.BackColor = Color.Black;
            hardLevelButton.BackColor = Color.Black;
            playAgainButton.BackColor = Color.Black;

            gameState = "2Player";
            gameLoop.Enabled = true;
            player1.X = 178;
            this.Focus();
        }

        private void easyLevelButton_Click(object sender, EventArgs e)
        {
            onePlayerButton.BackColor = Color.Black;
            twoPlayerButton.BackColor = Color.Black;
            easyLevelButton.BackColor = Color.Lime;
            mediumLevelButton.BackColor = Color.Black;
            hardLevelButton.BackColor = Color.Black;
            playAgainButton.BackColor = Color.Black;

            gameLevel = "easy";
            gameLoop.Enabled = true;
            this.Focus();
        }

        private void mediumLevelButton_Click(object sender, EventArgs e)
        {
            onePlayerButton.BackColor = Color.Black;
            twoPlayerButton.BackColor = Color.Black;
            easyLevelButton.BackColor = Color.Black;
            mediumLevelButton.BackColor = Color.Yellow;
            hardLevelButton.BackColor = Color.Black;
            playAgainButton.BackColor = Color.Black;

            gameLevel = "medium";
            gameLoop.Enabled = true;
            this.Focus();
        }
        private void hardLevelButton_Click(object sender, EventArgs e)
        {
            onePlayerButton.BackColor = Color.Black;
            twoPlayerButton.BackColor = Color.Black;
            easyLevelButton.BackColor = Color.Black;
            mediumLevelButton.BackColor = Color.Black;
            hardLevelButton.BackColor = Color.Red;
            playAgainButton.BackColor = Color.Black;

            gameLevel = "hard";
            gameLoop.Enabled = true;
            this.Focus();
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            onePlayerButton.BackColor = Color.Black;
            twoPlayerButton.BackColor = Color.Black;
            easyLevelButton.BackColor = Color.Black;
            mediumLevelButton.BackColor = Color.Black;
            hardLevelButton.BackColor = Color.Black;
            playAgainButton.BackColor = Color.Lime;

            GameSetup();
            this.Focus();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
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
                p2LivesLabel.Text = "";
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

                //draw aliens - wanted it to be 2 lines
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
                p2LivesLabel.Text = "";
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

                //draw aliens - wanted it to be 2 lines
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
            else if (gameState == "1Player" && gameLevel == "hard")
            {
                titleLabel.Text = "";
                gameOverLabel.Text = "";
                earthStateLabel.Text = "";
                p2LivesLabel.Text = "";
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

                //draw aliens - wanted it to be 2 lines
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

                ///draw safety basess
                e.Graphics.FillRectangle(greenBrush, safetyBase1);
                e.Graphics.FillRectangle(greenBrush, safetyBase2);
                e.Graphics.FillRectangle(greenBrush, safetyBase3);
                e.Graphics.FillRectangle(greenBrush, safetyBase4);

                //draw aliens - wanted it to be 2 lines
                for (int i = 0; i < aliens.Count; i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, aliens[i]);
                }

                //draw player lasers
                if (p1Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player1Laser);
                }
                
                if (p2Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player2Laser);
                }
                
                if (aLaser == true)
                {
                    e.Graphics.FillRectangle(whiteBrush, alienLaser);
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

                //draw aliens - wanted it to be 3 lines
                for (int i = 0; i < aliens.Count; i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, aliens[i]);
                }

                //draw player lasers
                if (p1Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player1Laser);
                }

                if (p2Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player2Laser);
                }

                if (aLaser == true)
                {
                    e.Graphics.FillRectangle(whiteBrush, alienLaser);
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

                //draw aliens - wanted it to be 5 lines
                for (int i = 0; i < aliens.Count; i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, aliens[i]);
                }

                //draw player lasers
                if (p1Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player1Laser);
                }

                if (p2Laser == true)
                {
                    e.Graphics.FillRectangle(greenBrush, player2Laser);
                }

                if (aLaser == true)
                {
                    e.Graphics.FillRectangle(whiteBrush, alienLaser);
                }
            }
            else if (gameState == "earthSaved")
            {
                gameLoop.Enabled = false;

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

                p1LivesLabel.Text = "";
                p2LivesLabel.Text = "";
                titleLabel.Text = "CONGRATULATIONS!";
                gameOverLabel.Text = "GAME OVER.";
                earthStateLabel.Text = "EARTH WAS SAVED!";

                if (player1Score > highscore && player1Score > player2Score)
                {
                    highscore = player1Score;
                    topScoreLabel.Text = $"{highscore}";
                }
                else if (player2Score > highscore && player2Score > player1Score)
                {
                    highscore = player2Score;
                    topScoreLabel.Text = $"{highscore}";
                }
                else if (player1Score == player2Score)
                {
                    highscore = player1Score;
                    topScoreLabel.Text = $"{highscore}";
                }
            }
            else if (gameState == "earthLost")
            {
                gameLoop.Enabled = false;

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

                p1LivesLabel.Text = "";
                p2LivesLabel.Text = "";
                titleLabel.Text = "YOU LOSE.";
                gameOverLabel.Text = "GAME OVER.";
                earthStateLabel.Text = "EARTH WAS LOST.";

                if (player1Score > highscore && player1Score > player2Score)
                {
                    highscore = player1Score;
                    topScoreLabel.Text = $"{highscore}";
                }
                else if (player2Score > highscore && player2Score > player1Score)
                {
                    highscore = player2Score;
                    topScoreLabel.Text = $"{highscore}";
                }
                else if (player1Score == player2Score)
                {
                    highscore = player1Score;
                    topScoreLabel.Text = $"{highscore}";
                }
            }
        }
    }
}
