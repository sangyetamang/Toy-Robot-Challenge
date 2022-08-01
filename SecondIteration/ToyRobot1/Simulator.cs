using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot2
{
    public class Simulator
    {
        Grid myTable = new Grid(5, 5);
        // robot starting from 0, 0, North position
        Robot myRobot;
        Direction setDirection;
        public Simulator()
        {

        }
        public void Menu()
        {
            Console.WriteLine("Instructions");
            Console.WriteLine("Place the Robot on Table");
            Console.WriteLine("Enter X position");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Y position");
            int y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type Direction");
            Console.WriteLine("Type N for North\n" +
                 "Type W for West\n" +
                 "Type E for East\n" +
                 "Type S for South\n");
            string strDirection = Console.ReadLine();
            Place(x, y, strDirection);
        }
        public void Place(int x, int y, string strDirection)
        {
            switch (strDirection)
            {
                case "N": setDirection = Direction.North; break;
                case "E": setDirection = Direction.East; break;
                case "S": setDirection = Direction.South; break;
                case "W": setDirection = Direction.West; break;
            }
            if (myTable.IsValidPosition(x, y))
            {
                myRobot = new Robot(x, y, setDirection);
            }
            else
            {
                Console.WriteLine("Invalid X or Y value");
            }
        }
        public void Play(string instruction)
        {
            switch (instruction)
            {
                case "M":
                    myRobot.Move();
                    Console.WriteLine(myRobot.Report());
                    break;
                case "R":
                    myRobot.TurnRight();
                    Console.WriteLine(myRobot.Report());
                    break;
                case "L":
                    myRobot.TurnLeft();
                    Console.WriteLine(myRobot.Report());
                    break;
            }
        }

        public string Report()
        {
            return myRobot.Report();
        }
    }
}
