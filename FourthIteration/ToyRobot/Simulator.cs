using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ToyRobot
{
    public enum MenuOption
    {
        Move,
        TurnRight,
        TurnLeft,
        Quit
    }
    public class Simulator
    {
        Grid myTable = new Grid(5, 5);

        Robot myRobot;
        Direction direction;
        // bool stop = true;

        public Simulator()
        {

        }

        //public bool Stop { get { return stop; } }
        public int ReadNumber(string input)
        {
            int number;
            bool isValidInput = false;

            while (!isValidInput)
            {
                if (int.TryParse(input, out number))
                {
                    number = int.Parse(input);
                    if (myTable.IsValidPosition(number))
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Number should be between 0 and 5");
                        input = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Not a number!");
                    input = Console.ReadLine();
                }
            }
            number = int.Parse(input);
            Console.WriteLine("Received Input: "+number);
            //is
            return number;
        }
        //method that prompts user for X, Y
        public int PromptUser(string prompt)
        {
            Console.WriteLine("To place the Robot on Table");
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            int position = 0;
            //Console.WriteLine("Inputs " + input);
            position = ReadNumber(input);
            return position;
        }
        public string GetDirection(string prompt)
        {
            Console.WriteLine(prompt);
            Console.WriteLine("Type N for North\n" +
                 "Type W for West\n" +
                 "Type E for East\n" +
                 "Type S for South\n");
            
            string input = Console.ReadLine().ToLower();

            while (input != "n" && input != "w" && input != "e" && input != "s")
            {
                Console.WriteLine("Invalid Direction.\n" +
                    " Please enter N for North, W for West, E for East and S for South");
                input = Console.ReadLine().ToLower();
            }

            return input;
        }

        //method that shows the menu to the user and read in the choice they made
        public MenuOption ReadUserInput()
        {
            while (true)
            {
                Console.WriteLine("\n1: Advance\n2: Turn Right\n3: Turn Left\n4: Quit");
                string inputAsString = Console.ReadLine();
                int number;
                if (Int32.TryParse(inputAsString, out number))//validates user selection and assigns it to number int variable
                {
                    number = Convert.ToInt32(inputAsString);
                    if (number > 4 || number < 1) //checks if the input is in the range of 1 to 4.
                    {
                        Console.WriteLine("Input must be in the range of 1 to 4 inclusive. Please enter again!");
                        Console.WriteLine((MenuOption)(number - 1));
                    }
                }
                else
                {
                    Console.WriteLine("Not a number. Try again");
                }

                return (MenuOption)(number - 1);
            }

        }
        public void Menu()
        {
            Console.WriteLine("Instructions");
            int xPosition = PromptUser("Enter X position. The value must be between 0 and 5");
            int yPosition = PromptUser("Enter Y position. The value must be between 0 and 5");
            string strDirection = GetDirection("Type Direction");
            Place(xPosition, yPosition, strDirection);
            myRobot.Report();
            //ReadUserInput();
        }
        public void Place(int x, int y, string strDirection)
        {
            if (strDirection == "n") direction = Direction.North;
            if (strDirection == "e") direction = Direction.East;
            if (strDirection == "s") direction = Direction.South;
            if (strDirection == "w") direction = Direction.West;

            myRobot = new Robot(x, y, direction);
        }
        public void Play(MenuOption instruction)
        {
            switch (instruction)
            {
                case MenuOption.Move:
                    myRobot.Move();
                    Console.WriteLine(myRobot.Report());
                    break;
                case MenuOption.TurnRight:
                    myRobot.TurnRight();
                    Console.WriteLine(myRobot.Report());
                    break;
                case MenuOption.TurnLeft:
                    myRobot.TurnLeft();
                    Console.WriteLine(myRobot.Report());
                    break;
                case MenuOption.Quit:
                    Console.WriteLine("THANK YOU FOR PLAYING");
                    break;
            }
        }

        public string Report()
        {
            return myRobot.Report();
        }
    }
}

