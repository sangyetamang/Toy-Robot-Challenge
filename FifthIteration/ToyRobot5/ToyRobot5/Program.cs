using System;

namespace ToyRobot5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fifth Iteration");

            // start simulator
            Simulator mySimulator = new Simulator();

            // show menu for user to start the game
            mySimulator.ShowMenu();

            bool stop = false;
            do
            {
                try
                {
                    // read user's selection to place the robot on the board
                    MenuOption userSelection = mySimulator.ReadUserInput();

                    if (userSelection == MenuOption.Quit)
                    {
                        // stop the game
                        stop = true;
                    }

                    // unless user doesn't select quit option, keep playing the game
                    mySimulator.Play(userSelection);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (stop != true);
        }
    }
}

