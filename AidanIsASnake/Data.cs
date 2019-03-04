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

    public enum GameStates
    {
        Spawning,
        Playing,
        Paused,
        Dead
    }

    class Data
    {
        public static int Score { get; set; }               //Total score
        public static Directions direction { get; set; }    //Current direction
        public static GameStates GameState { get; set; }

        public Data()
        {
            Score = 0;
            direction = Directions.Down;
            GameState = GameStates.Spawning;
        }
    }
}
