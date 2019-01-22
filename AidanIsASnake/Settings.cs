using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidanIsASnake
{
    public enum Difficulties
    {
        Pepega,
        Normal,
        Hard,
        DarkSouls
    };

    class Settings
    {
        //Block dimensions
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Points { get; set; }          //Points for each food block eaten
        public static Difficulties difficulty { get; set; }

        public Settings()
        {
            //Initial values
            Width = 16;
            Height = 16;
            Speed = 20;
            Points = 50;
            difficulty = Difficulties.Normal;
        }

    }
}
