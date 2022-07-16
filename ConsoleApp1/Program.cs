using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First Iteration");

            // 5x5 table
            Grid myTable = new Grid(5, 5);
            // robot starting from 0, 0, North position
            Robot myRobot = new Robot(Direction.North, 0, 0);

            myRobot.Move();
            Console.WriteLine(myRobot.Report()); // North, 0, 1

            myRobot.TurnLeft();
            Console.WriteLine(myRobot.Report()); // West, 0, 1

            myRobot.TurnRight();
            Console.WriteLine(myRobot.Report()); // North, 0, 1

        }
    }
}
