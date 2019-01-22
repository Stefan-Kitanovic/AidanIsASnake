using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AidanIsASnake
{
    class Input
    {
        private static Hashtable KeyTable = new Hashtable();

        //Returns bool whether a key is pressed or not
        public static bool keyPress(Keys key)
        {
            if (KeyTable[key] == null)
                return false;

            return (bool)KeyTable[key];
        }

        //Changes state of the keys
        public static void changeState(Keys key, bool state)
        {
            KeyTable[key] = state;
        }
        

    }
}
