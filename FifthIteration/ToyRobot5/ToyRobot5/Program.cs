using System;

namespace ToyRobot5
{
    class Tester
    {

        private static bool CheckRobotPosition(int[] expectedPos, Direction expectedDirection, Robot robot)
        {
            Console.WriteLine(expectedPos[0] == robot.X);
            Console.WriteLine(expectedPos[1] == robot.Y);
            Console.WriteLine(expectedDirection == robot.direction); // for debugging
            //Console.WriteLine(expectedPos[0] != robot.X || expectedPos[1] != robot.Y || expectedDirection != robot.direction);
            if (expectedPos[0] == robot.X && expectedPos[1] == robot.Y && expectedDirection == robot.direction)
            {
                Console.WriteLine("PASS");
                return true;
            }
            else return false;
        }
        // start simulator
        //Simulator mySimulator = new Simulator();
        static void ProcessCommands(Robot robot, string command)
        {
            string[] CommandsParts = command.Split();
            string commandType = CommandsParts[0];

            if (commandType == "PLACE")
            {
                string[] args = CommandsParts[1].Split(',');
                int x = int.Parse(args[0]);
                int y = int.Parse(args[1]);
                string facing = args[2];
                robot.Place(x, y, facing);
            }
            else if (commandType == "MOVE")
            {
                robot.Move();
            }
            else if (commandType == "REPORT")
            {
                Console.WriteLine(robot.GetReport());
            }
            else if (commandType == "RIGHT")
            {
                robot.TurnRight();
            }
            else if (commandType == "LEFT")
            {
                robot.TurnLeft();
            }
        }

        static void RunRobotSimulation(Robot robot, string[] commands)
        {
            
            foreach (string command in commands)
            {
                ProcessCommands(robot, command);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\nTest A: PLACE 0,0,NORTH, MOVE, REPORT");
                Robot robot1 = new Robot();
                string[] commands1 =
                        {
                            "PLACE 0,0,NORTH",
                            "MOVE",
                            "REPORT"
                        };
                RunRobotSimulation(robot1, commands1);
                int[] positions = { 0, 1 };
                Direction expectedDirection = (Direction)Enum.Parse(typeof(Direction), "NORTH");
                if (CheckRobotPosition(positions, expectedDirection, robot1) == true)
                {
                    Console.WriteLine(" :: PASS:: ");// + robot1.GetReport());
                }
                else
                {
                    Console.WriteLine(" :: FAIL ::");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: ") ;
                Console.WriteLine(exception.ToString());
                //result = result + "-";
            }


            try
            {
                Console.WriteLine("\nTest B: PLACE 1,3,SOUTH, LEFT, REPORT");
                Robot robot2 = new Robot();
                string[] commands2 =
                        {
                            "PLACE 1,3,SOUTH",
                            "LEFT",
                            "REPORT"
                        };
                RunRobotSimulation(robot2, commands2);
                int[] positions2 = { 1, 3 };
                Direction expectedDirection2 = (Direction)Enum.Parse(typeof(Direction), "EAST");
                if (CheckRobotPosition(positions2, expectedDirection2, robot2))
                {
                    Console.WriteLine(" :: PASS:: " + robot2.GetReport());
                }
                else
                {
                    Console.WriteLine(" :: FAIL ::");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: "); //+ list.ToString()) ;
                Console.WriteLine(exception.ToString());
            }

            try
            {
                Console.WriteLine("\nTest C: PLACE 2,2,SOUTH, MOVE, MOVE, REPORT");
                Robot robot3 = new Robot();
                string[] commands3 =
                        {
                            "PLACE 2,3,SOUTH",
                            "MOVE",
                            "MOVE",
                            "REPORT"
                        };
                Robot testRobot = new Robot(2, 2, Direction.SOUTH);
                testRobot.Move();
                testRobot.Move();
                Console.WriteLine("Test REport " + testRobot.GetReport());
                RunRobotSimulation(robot3, commands3);
                int[] positions3 = { 2, 0};
                Direction expectedDirection3 = (Direction)Enum.Parse(typeof(Direction), "NORTH");
                
                if (CheckRobotPosition(positions3, expectedDirection3, robot3))
                {
                    Console.WriteLine(" :: PASS:: " + robot3.GetReport());
                }
                else
                {
                    Console.WriteLine(" :: FAIL ::");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: "); //+ list.ToString()) ;
                Console.WriteLine(exception.ToString());
                //result = result + "-";
            }
        }
    }
}

