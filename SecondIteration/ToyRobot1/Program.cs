using System;

namespace ToyRobot2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Second Iteration");
            Simulator mySimulator = new Simulator();
            mySimulator.Menu();
            bool stop = false;
            Console.WriteLine(mySimulator.Report());
            do
            {
                Console.WriteLine("M for move, L for Left, R for Right");
                string command = Console.ReadLine();
                mySimulator.Play(command);
            } while (stop != true);
            /*
            // 5x5 table
            Grid myTable = new Grid(5, 5);
            // robot starting from 0, 0, North position
            Robot myRobot = new Robot( 0, 0, Direction.North);
           
            bool valid = myTable.IsValidPosition(myRobot.X,myRobot.Y);
            Console.WriteLine(valid);
            Robot myRobot2 = new Robot(0, -1, Direction.North);
            Console.WriteLine(myTable.IsValidPosition(myRobot2.X, myRobot2.Y));

            myRobot.Move();
            Console.WriteLine(myRobot.Report()); // North, 0, 1

            myRobot.TurnLeft();
            Console.WriteLine(myRobot.Report()); // West, 0, 1

            myRobot.TurnRight();
            Console.WriteLine(myRobot.Report()); // North, 0, 1

            Simulator mySimulator = new Simulator();
            mySimulator.Place(-1, 2, Direction.East);
            */
        }
    }
}

