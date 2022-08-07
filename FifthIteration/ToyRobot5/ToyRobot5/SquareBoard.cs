using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot5
{
    public class SquareBoard
    {
        private int length;
        // constructor
        public SquareBoard(int length)
        {
            this.length = length;
        }

        // getter
        public int Length
        {
            get
            {
                return length;
            }
        }

        //check if x is withing the boundary of the board
        public bool IsWithinBound(int x)
        {
            return x <= length && x >= 0;
        }
    }
}
