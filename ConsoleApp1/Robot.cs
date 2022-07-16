using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
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
        North,
        East,
        South,
        West
    }
    public class Robot
    {
        public Direction direction;
        int x;
        int y;

        //constructor
        public Robot(Direction direction, int x, int y)
        {
            this.direction = direction;
            this.x = x;
            this.y = y;
        }

        //move the toy robot one unit forward in the direction it is currently facing
        public void Move()
        {
            //move the toy one unit forward
            switch(direction)
            {
                case Direction.North:
                    y++;
                    break;
                case Direction.South:
                    y--;
                    break;
                case Direction.East:
                    x++;
                    break;
                case Direction.West:
                    x--;
                    break;
            }
        }
        //TurnRight() method rotates the robot 90 degrees in the specified direction (clockwise)
        //without changing the position of the robot.

        public void TurnRight()
        {
            switch (direction)
            {
                case Direction.North:
                    direction = Direction.East;
                    break;
                case Direction.East:
                    direction = Direction.South;
                    break;
                case Direction.South:
                    direction = Direction.West;
                    break;
                case Direction.West:
                    direction = Direction.North;
                    break;
            }
        }

        //TurnLeft() method rotates the robot 90 degrees in the specified direction (anti-clockwise)
        //without changing the position of the robot.
        public void TurnLeft()
        {
            switch (direction)
            {
                case Direction.North:
                    direction = Direction.West;
                    break;
                case Direction.West:
                    direction = Direction.South;
                    break;
                case Direction.South:
                    direction = Direction.North;
                    break;
                case Direction.East:
                    direction = Direction.North;
                    break;
            }
        }


        public string Report()
        {
            return "Position Report: "+ x + ", " + y + ", "+ direction;
        }

    }
}
