﻿using System;
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
        int alienHeight = 30;
        int alienWidth = 30;

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
        Pen whitePen = new Pen(Color.White);
        SolidBrush greenBrush = new SolidBrush(Color.LawnGreen);
        Pen greenPen = new Pen(Color.LawnGreen);

        string gameState = "waiting";
        string gameLevel = "waiting";

        public Form1()
        {
            InitializeComponent();
            aliens.Add(new Rectangle(50, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(150, 60, alienWidth, alienHeight));
            aliens.Add(new Rectangle(250, 60, alienWidth, alienHeight));


        }

        public void GameSetup()
        {
            // clear outputs and make buttons invisible
            gameState = "running";
            titleLabel.Text = "";
            gameOverLabel.Text = "";
            earthStateLabel.Text = "";
            easyLevelButton.Visible = false;
            mediumLevelButton.Visible = false;
            hardLevelButton.Visible = false;
            onePlayerButton.Visible = false;
            twoPlayerButton.Visible = false;

            // reset scores and enable game loop
            player1Score = 0000;
            player2Score = 0000;
            p1Score.Text = "0000";
            p2Score.Text = "0000";
            gameLoop.Enabled = true;

            //reset players positions
            aliens.Clear();
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

            //make the aliens bounce off the right side
            for (int i = 0; i < aliens.Count; i++)
            {
                if (aliens[i].X > this.Width - aliens[i].Width)
                {
                    alienSpeed = alienSpeed * -1;
                }
            }

            //make the aliens bounce off the left side
            for (int i = 0; i < aliens.Count; i++)
            {
                if (alienSpeed == -5 && aliens[i].X == 0)
                {
                    alienSpeed = alienSpeed * -1;
                }
            }

            // check for button press for player lasers, only allow one at a time

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

            // check for an alien laser, only one at a time

            // check for player collisions with alien lasers,
            // if they collide take that player's life and reset posiiton,
            // remove that laser
            for (int i = 0; i < aliens.Count; i++)
            {
                if (player1.IntersectsWith(alienLaser))
                {
                    player1.X = 260;
                    player1.Y = 335;
                    player1Lives--;
                }
                else if (player2.IntersectsWith(alienLaser))
                {
                    player2.X = 338;
                    player2.Y = 335;
                    player2Lives--;
                }
            }

            // check for alien collisions with player lasers,
            // if they collide remove that alien, give point to player, 
            // remove that laser
            for (int i = 0; i < aliens.Count; i++)
            {
                if (aliens[i].IntersectsWith(player1Laser))
                {
                    p1Laser = false;
                    player1Laser.X = -30;
                    player1Laser.Y = -30;
                    aliens.RemoveAt(i);
                    player1Score += 15;
                    p1Score.Text = $"{player1Score}";
                }
                else if (aliens[i].IntersectsWith(player2Laser))
                {
                    p2Laser = false;
                    player1Laser.X = -30;
                    player1Laser.Y = -30;
                    aliens.RemoveAt(i);
                    player2Score += 15;
                    p2Score.Text = $"{player2Score}";
                }
            }

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
                player1Laser.X = -30;
                player1Laser.Y = -30;
                p1Laser = false;
            }
            else if (player2Laser.IntersectsWith(safetyBase1) || (player2Laser.IntersectsWith(safetyBase2))
                || (player2Laser.IntersectsWith(safetyBase3)) || (player2Laser.IntersectsWith(safetyBase4)))
            {
                player2Laser.X = -30;
                player2Laser.Y = -30;
                p2Laser = false;
            }
            else if (alienLaser.IntersectsWith(safetyBase1) || (alienLaser.IntersectsWith(safetyBase2))
                || (alienLaser.IntersectsWith(safetyBase3)) || (player1Laser.IntersectsWith(safetyBase4)))
            {
                {
                    player2.X = 338;
                    player2.Y = 335;
                    player2Lives--;
                }
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                p1Score.Text = "0000";
                p2Score.Text = "0000";
                titleLabel.Text = "SPACE INVADERS";
                gameOverLabel.Text = "";
                earthStateLabel.Text = "";
                easyLevelButton.Visible = true;
                mediumLevelButton.Visible = true;
                hardLevelButton.Visible = true;
                onePlayerButton.Visible = true;
                twoPlayerButton.Visible = true;

                easyLevelButton.Enabled = true;
                mediumLevelButton.Enabled = true;
                hardLevelButton.Enabled = true;
                onePlayerButton.Enabled = true;
                twoPlayerButton.Enabled = true;
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

                easyLevelButton.Enabled = false;
                mediumLevelButton.Enabled = false;
                hardLevelButton.Enabled = false;
                onePlayerButton.Enabled = false;
                twoPlayerButton.Enabled = false;

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

                easyLevelButton.Enabled = false;
                mediumLevelButton.Enabled = false;
                hardLevelButton.Enabled = false;
                onePlayerButton.Enabled = false;
                twoPlayerButton.Enabled = false;

                gameLoop.Enabled = false;
                titleLabel.Text = "YOU LOSE.";
                gameOverLabel.Text = "GAME OVER.";
                earthStateLabel.Text = "EARTH WAS LOST.";

            }
        }
    }
}
