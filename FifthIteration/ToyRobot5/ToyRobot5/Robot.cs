using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot5
{
    /* Just for my reference:
          N
          |
     W ___|___ E
          |
          |
          S
     N, S -> y axis
     E, W -> x axis
     */
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }
    public class Robot
    {
        public Direction direction;
        private int x;
        private int y;
        private SquareBoard myBoard = new SquareBoard(5);

        //constructor
        public Robot() { }
      
        // constructor with params
        public Robot(int X, int Y, Direction NewDirection)
        {
            this.x = X;
            this.y = Y;
            this.direction = NewDirection;
        }
        public SquareBoard MyBoard { get { return myBoard; } }

        public int X { get { return x; } }

        public int Y { get {  return y; } }

        // stop the robot from going out of the board
        public int PreventFall(int location)
        {
            if (location >= myBoard.Length)
            {
                return myBoard.Length;
            }
            else if (location <= 0)
            {
                return 0;
            }
            else
                return location;
        }

        public void Place(int newX, int newY, string facing)
        {
            //Console.WriteLine(Enum.IsDefined(typeof(Direction), facing));
            if (MyBoard.IsWithinBound(newX) && MyBoard.IsWithinBound(newY) && Enum.IsDefined(typeof(Direction), facing))
            {
                x = newX;
                y = newY;
                direction = (Direction)Enum.Parse(typeof(Direction), facing);
            }
        }
        //move the toy robot one unit forward in the direction it is currently facing
        public void Move()
        {
            //move the toy one unit forward

            switch (direction)
            {
                case Direction.NORTH:
                    y++;
                    break;
                case Direction.SOUTH:
                    y--;
                    break;
                case Direction.EAST:
                    x++;
                    break;
                case Direction.WEST:
                    x--;
                    break;
            }
            y = PreventFall(y);
            x = PreventFall(x);
        }

        //TurnRight() method rotates the robot 90 degrees in the specified direction (clockwise)
        //without changing the position of the robot.
        public void TurnRight()
        {
            direction++;
            if ((int)direction > 3)
            {
                direction = 0;
            }

        }

        //TurnLeft() method rotates the robot 90 degrees in the specified direction (anti-clockwise)
        //without changing the position of the robot.
        public void TurnLeft()
        {
            direction--;
            if ((int)direction < 0)
            {
                direction = (Direction)3;
            }
        }

        // get report of the robot's position
        public string GetReport()
        {
            return "Robot is at position (" + x + ", " + y + ", " + direction + ")";
        }

    }
}
