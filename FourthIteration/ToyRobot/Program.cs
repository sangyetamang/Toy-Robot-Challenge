using System;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fourth Iteration");
            Simulator mySimulator = new Simulator();
            mySimulator.Menu();
            bool stop = false;
            Console.WriteLine(mySimulator.Report());
            do
            {
                try
                {
                    MenuOption userSelection = mySimulator.ReadUserInput();
                    if (userSelection == MenuOption.Quit)
                    {
                        stop = true;
                    }
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
