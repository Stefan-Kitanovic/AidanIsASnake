using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
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

        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public Form1()
        {
            InitializeComponent();
            //Adding settings and data for the game
            new Settings(); 
            new Data();


            //Volume slider
            uint currentVolume = 0;                                             //Set the volume to 0 by default
            waveOutGetVolume(IntPtr.Zero, out currentVolume);                   //Assigns the volume
            ushort calculatedVolume = (ushort)(currentVolume & 0x0000ffff);     //Calculates the volume
            volumeSlider.Value = calculatedVolume / (ushort.MaxValue / 100);      //Volume on a scale of 1 to 100

            //Game boundaries
            maxXpos = (gameBackground.Size.Width - Settings.Width/2) / Settings.Width;      //Has to be set this way
            maxYpos = (gameBackground.Size.Height - Settings.Height/2) / Settings.Height;   //to prevent a bug that allows snake to go beyond bottom border

            difficultySlider.Enabled = false;
            difficultySlider.Value = 1;
            difficultySlider.Maximum = 3;

            gameTimer.Interval = 1000 / Settings.Speed; //Interval depends on the speed set in the settings
            gameTimer.Tick += screenUpdate; //Updating the screen on every tick
            gameTimer.Start();

            spawn();
        }

        //Ran on every single tick
        private void screenUpdate(object sender, EventArgs e)
        {
            this.ActiveControl = null;  //Makes it so the components don't take focus thus disabling key reading
            difficultyLabel.Text = "Diffculty: " + Settings.difficulty.ToString(); //Displays the current difficulty
            gameScoreNumLabel.Text = Data.Score.ToString(); //Shows the score on the screen
            volumeLabel.Text = "Volume: " + volumeSlider.Value.ToString();

            //Game over screen
            if (Data.GameState == GameStates.Spawning)
            {
                //Start the game when the player presses enter
                if (Input.keyPress(Keys.Enter))
                    startGame();

                gameEndMsgLabel.Visible = false; //Hide the game over screen
                gamePausedLabel.Visible = false;

                gameScoreNumLabel.Text = Data.Score.ToString(); //Shows the score on the screen

                gameSpawningText.Visible = true;
                gameSpawningText.Text = "Press ENTER to start";

                difficultySlider.Enabled = true;
            }
            else if (Data.GameState == GameStates.Paused)
            {
                difficultySlider.Enabled = false;
                gamePausedLabel.Visible = true;
                gamePausedLabel.Text = "Game is paused\nPress ENTER to resume";

                if (Input.keyPress(Keys.Enter))
                    Data.GameState = GameStates.Playing;
            }
            else if (Data.GameState == GameStates.Dead)
            {
                gameEndMsgLabel.Text = "Game over\n" + "Your score is: " + Data.Score + "\nPress ENTER to restart\nPress ESC to spawn";
                gameEndMsgLabel.Visible = true;

                if (Input.keyPress(Keys.Enter))
                    startGame();

                if (Input.keyPress(Keys.Escape))
                    spawn();

                difficultySlider.Enabled = true;
            }
            else
            {
                //Game not over(yet)
                gameEndMsgLabel.Visible = false; //Hide the game over screen
                gameSpawningText.Visible = false;//Hides the spawning screen
                gamePausedLabel.Visible = false; //Hides the pause screen

                difficultySlider.Enabled = false;

                if (Input.keyPress(Keys.Space))
                    pause();

                //Direction is changed based on the button that's pressed
                if (Input.keyPress(Keys.D) && Data.direction != Directions.Left)        //Pressing D makes it go right
                {
                    Data.direction = Directions.Right;
                }
                else if (Input.keyPress(Keys.A) && Data.direction != Directions.Right)  //Pressing A makes it go left
                {
                    Data.direction = Directions.Left;
                }
                else if (Input.keyPress(Keys.W) && Data.direction != Directions.Down)   //Pressing W makes it go up
                {
                    Data.direction = Directions.Up;
                }
                else if (Input.keyPress(Keys.S) && Data.direction != Directions.Up)     //Pressing S makes it go down
                {
                    Data.direction = Directions.Down;
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
                    switch (Data.direction)
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
                        die(); //ded †
                    }

                    //Collision detection for the body
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                            die(); //ded †
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
            Data.Score += Settings.Points; //Increases the score
            gameScoreNumLabel.Text = Data.Score.ToString(); //Display the score on the screen

            try
            {
                //SoundPlayer eatSound = new SoundPlayer(AidanIsASnake.Properties.Resources.eat);
                //eatSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading eating sound");
            }

            generateFood(); //Makes a new food block since the previous one was eaten
        }

        private void startGame()
        {
            new Data(); //Reset the data
            Data.GameState = GameStates.Playing;
            Snake.Clear(); //Clears the list of snake parts
            Block head = new Block { X = 10, Y = 5 }; //Spawns the head of the snake
            Snake.Add(head); //Adds the head to the list

            try
            {
                SoundPlayer gameSong = new SoundPlayer(AidanIsASnake.Properties.Resources.gas_gas_gas);
                gameSong.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading game song");
            }

            generateFood(); //Generates the starting food
        }

        private void spawn()
        {
            Data.GameState = GameStates.Spawning;
            new Data(); //Reset the data
        }

        private void pause()
        {
            Data.GameState = GameStates.Paused;
        }

        private void die()
        {
            Data.GameState = GameStates.Dead;

            try
            {               
                SoundPlayer deathSound = new SoundPlayer(AidanIsASnake.Properties.Resources.you_died);
                deathSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading death sound");
            }
            
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

            if (!(Data.GameState == GameStates.Dead)) //If game is not over
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
        }

        private void changeDifficulty()
        {
            switch (Settings.difficulty)
            {
                case Difficulties.Pepega:
                    Settings.Points = 20;
                    Settings.Speed = 10;
                    break;

                case Difficulties.Normal:
                    Settings.Points = 50;
                    Settings.Speed = 20;
                    break;

                case Difficulties.Hard:
                    Settings.Points = 100;
                    Settings.Speed = 35;
                    break;

                case Difficulties.DarkSouls:
                    Settings.Points = 200;
                    Settings.Speed = 50;
                    break;                  
            }

            gameTimer.Interval = 1000 / Settings.Speed; //Interval depends on the speed set in the settings
        }

        private void difficultySlider_Scroll(object sender, EventArgs e)
        {
            switch (difficultySlider.Value)
            {
                case 0:
                    Settings.difficulty = Difficulties.Pepega;
                    break;
                case 1:
                    Settings.difficulty = Difficulties.Normal;
                    break;
                case 2:
                    Settings.difficulty = Difficulties.Hard;
                    break;
                case 3:
                    Settings.difficulty = Difficulties.DarkSouls;
                    break;
            }

            changeDifficulty();
        }

        private void volumeSlider_Scroll(object sender, EventArgs e)
        {
            int newVolume = ((ushort.MaxValue / 100) * volumeSlider.Value);                             //Calculates the selected volume
            uint newVolumeAllChannels = (((uint)newVolume & 0x0000ffff) | ((uint)newVolume << 16));     //Sets the volume for both channels
            waveOutSetVolume(IntPtr.Zero, newVolumeAllChannels);                                        //Sets the final volume
        }

        private void playSound(string audioPath)
        {
            
        }
    }
}
