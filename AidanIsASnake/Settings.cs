using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidanIsASnake
{
    public enum Directions
    {
        Left,
        Right,
        Up,
        Down
    };

    class Settings
    {
        //Block dimensions
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static int Speed { get; set; }
        public static int Score { get; set; }           //Total score
        public static int Points { get; set; }          //Points for each food block eaten
        public static bool GameOver { get; set; }
        public static Directions direction { get; set; }

        public Settings()
        {
            //Initial values
            Width = 16;
            Height = 16;
            Speed = 10;
            Score = 0;
            Points = 100;
            GameOver = false;
            direction = Directions.Down;
        }

    }
}
