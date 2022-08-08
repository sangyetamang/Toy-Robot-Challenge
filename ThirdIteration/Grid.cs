using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
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

        public bool IsValidPosition(int x, int y)
        {
            return (x <= 5 && x >= 0) && (y <= 5 && y >= 0);
        }
    }
}
