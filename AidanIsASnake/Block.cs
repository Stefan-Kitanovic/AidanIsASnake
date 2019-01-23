using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidanIsASnake
{
    enum GraphicsBlockTypes
    {
        headUp,
        headRight,
        headDown,
        headLeft,
        tailUp,
        tailRight,
        tailDown,
        tailLeft,
        cornerUpRight,
        cornerDownRight,
        cornerDownLeft,
        cornerUpLeft,
        bodyUpDown,
        bodyLeftRight,
        food,
        background
    };

    class Block
    {
        public int X { get; set; } //X coord
        public int Y { get; set; } //Y coord 

        public Block()
        {
            X = 0;
            Y = 0;
        }

        public static GraphicsBlockTypes[] blockTypesArray = new GraphicsBlockTypes[] { GraphicsBlockTypes.headUp,
                                                                                        GraphicsBlockTypes.headRight,
                                                                                        GraphicsBlockTypes.headDown,
                                                                                        GraphicsBlockTypes.headLeft,
                                                                                        GraphicsBlockTypes.tailUp,
                                                                                        GraphicsBlockTypes.tailRight,
                                                                                        GraphicsBlockTypes.tailDown,
                                                                                        GraphicsBlockTypes.tailLeft,
                                                                                        GraphicsBlockTypes.cornerUpRight,
                                                                                        GraphicsBlockTypes.cornerDownRight,
                                                                                        GraphicsBlockTypes.cornerDownLeft,
                                                                                        GraphicsBlockTypes.cornerUpLeft,
                                                                                        GraphicsBlockTypes.bodyUpDown,
                                                                                        GraphicsBlockTypes.bodyLeftRight,
                                                                                        GraphicsBlockTypes.food,
                                                                                        GraphicsBlockTypes.background};
    }
}
