using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AidanIsASnake
{
    public partial class Form1 : Form
    {
        private List<Block> Snake = new List<Block>(); //Snake consists of list array of blocks duh
        private Block food = new Block(); //
        private int maxXpos;
        private int maxYpos;


        public Form1()
        {
            InitializeComponent();
            new Settings(); //Adding the settings for the game

            //Game boundaries
            maxXpos = gameBackground.Size.Width / Settings.Width;
            maxYpos = gameBackground.Size.Height / Settings.Height;

            gameTimer.Interval = 1000 / Settings.Speed; //Interval depends on the speed set in the settings
            gameTimer.Tick += screenUpdate; //Updating the screen on every tick
            gameTimer.Start();

            startGame();
        }

        //Ran on every single tick
        private void screenUpdate(object sender, EventArgs e)
        {
            //Game over screen
            if (Settings.GameOver == true)
            {
                //Restart the game when the player presses enter
                if (Input.keyPress(Keys.Enter))
                    startGame();
            }
            else
            {
                //Game not over(yet)
                //Direction is changed based on the button that's pressed

                if (Input.keyPress(Keys.D) && Settings.direction != Directions.Left)        //Pressing D makes it go right
                {
                    Settings.direction = Directions.Right;
                }
                else if (Input.keyPress(Keys.A) && Settings.direction != Directions.Right)  //Pressing A makes it go left
                {
                    Settings.direction = Directions.Left;
                }
                else if (Input.keyPress(Keys.W) && Settings.direction != Directions.Down)   //Pressing W makes it go up
                {
                    Settings.direction = Directions.Up;
                }
                else if (Input.keyPress(Keys.S) && Settings.direction != Directions.Up)     //Pressing S makes it go down
                {
                    Settings.direction = Directions.Down;
                }

                movePlayer();   //Self explanatory
            }

            gameBackground.Invalidate(); //Updates the screen
        }

        private void movePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //If it's the head
                if (i == 0)
                {
                    //Move the body depending on the direction of head
                    switch (Settings.direction)
                    {
                        case Directions.Right:
                            Snake[i].X++;
                            break;
                        case Directions.Left:
                            Snake[i].X--;
                            break;
                        case Directions.Up:
                            Snake[i].Y--;
                            break;
                        case Directions.Down:
                            Snake[i].Y++;
                            break;
                    }
                    
                    //Collision detection for the boundaries
                    if (Snake[i].X < 0 ||
                        Snake[i].Y < 0 ||
                        Snake[i].X > maxXpos ||
                        Snake[i].Y > maxYpos)
                    {
                        Settings.GameOver = true; //ded †
                    }

                    //Collision detection for the body
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                            Settings.GameOver = true; //ded †
                    }
                     
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        eat(); //Chunga chunga chunga chunga
                    }

                }
                else //Moving the rest of the body if there are no collisions
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void generateFood()
        {
            Random rnd = new Random();

            //Generate a food block on random location on screen
            food = new Block { X = rnd.Next(0, maxXpos), Y = rnd.Next(0, maxYpos) };
        }

        private void eat()
        {
            //Crates a new block at the end of the snake
            Block newBodyPart = new Block
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(newBodyPart); //Adds the created block to the list
            Settings.Score += Settings.Points; //Increases the score
            gameScoreNumLabel.Text = Settings.Score.ToString(); //Display the score on the screen
            generateFood(); //Makes a new food block since the previous one was eaten
        }

        private void startGame()
        {
            gameEndMsgLabel.Visible = false; //Hide the game over screen
            new Settings(); //Reset the settings
            Snake.Clear(); //Clears the list of snake parts
            Block head = new Block { X = 10, Y = 5 }; //Spawns the head of the snake
            Snake.Add(head); //Adds the head to the list
            gameScoreNumLabel.Text = Settings.Score.ToString(); //Shows the score on the screen

            generateFood(); //Generates the starting food
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, true); //Updates the keyTable when a key is pressed
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, false); //Updates the keyTable when a key is let go of
        }

        private void graphicsUpdate(object sender, PaintEventArgs e)
        {
            Graphics screen = e.Graphics;

            if (!Settings.GameOver) //If game is not over
            {
                Brush snakeColour = Brushes.Black; //Makes the snake a TriHard

                for (int i = 0; i < Snake.Count; i++)
                {
                    //Draws the snake
                    screen.FillEllipse(snakeColour,
                                        new Rectangle(
                                            Snake[i].X * Settings.Width,
                                            Snake[i].Y * Settings.Height,
                                            Settings.Width,
                                            Settings.Height));

                    //Draws food
                    screen.FillEllipse(Brushes.Green,
                                        new Rectangle(
                                            food.X * Settings.Width,
                                            food.Y * Settings.Height,
                                            Settings.Width,
                                            Settings.Height));
                }
            }
            else  //ded †
            {
                gameEndMsgLabel.Text = "Game over\n" + "Your score is: " + Settings.Score + "\nPress ENTER to restart\n";
                gameEndMsgLabel.Visible = true;
            }
       
        }
    }
}
