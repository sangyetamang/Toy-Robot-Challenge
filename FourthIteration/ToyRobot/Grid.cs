using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    class Grid
    {
        public int width;
        public int length;

        public Grid(int width, int length)
        {
            this.width = width;
            this.length = length;
        }

        public bool IsValidPosition(int x)
        {
            return x <= width && x >= 0;
        }


    }
}
