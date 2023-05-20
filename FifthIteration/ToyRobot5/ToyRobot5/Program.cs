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
            // TEST 1
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
                int[] expectedPosition1 = { 0, 1 };
                Direction expectedDirection1 = (Direction)Enum.Parse(typeof(Direction), "NORTH");
                if (CheckRobotPosition(expectedPosition1 , expectedDirection1, robot1) == true)
                {
                    Console.WriteLine(" :: PASS:: ");
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
            }

            // TEST 2
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
                int[] expectedPosition2 = { 1, 3 };
                Direction expectedDirection2 = (Direction)Enum.Parse(typeof(Direction), "EAST");
                if (CheckRobotPosition(expectedPosition2, expectedDirection2, robot2))
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

            // TEST 3
            try
            {
                Console.WriteLine("\nTest C: PLACE 2,2,SOUTH, MOVE, MOVE, REPORT");
                Robot robot3 = new Robot();
                string[] commands3 =
                        {
                            "PLACE 2,2,SOUTH",
                            "MOVE",
                            "MOVE",
                            "REPORT"
                        };
                RunRobotSimulation(robot3, commands3);
                int[] expectedPosition3 = { 2, 0};
                Direction expectedDirection3 = (Direction)Enum.Parse(typeof(Direction), "SOUTH");
                
                if (CheckRobotPosition(expectedPosition3, expectedDirection3, robot3))
                {
                    Console.WriteLine(" :: PASS:: ");
                }
                else
                {
                    Console.WriteLine(" :: FAIL ::");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: ");
                Console.WriteLine(exception.ToString());
            }

            // test 4
            try
            {
                Console.WriteLine("\nTest D: PLACE 2,2,SOUTH, LEFT, LEFT, REPORT");
                Robot robot4 = new Robot();
                string[] commands3 =
                        {
                            "PLACE 2,2,SOUTH",
                            "LEFT",
                            "LEFT",
                            "MOVE",
                            "REPORT"
                        };
                RunRobotSimulation(robot4, commands3);
                int[] expectedPosition4 = { 2, 3};
                Direction expectedDirection4 = (Direction)Enum.Parse(typeof(Direction), "NORTH");

                if (CheckRobotPosition(expectedPosition4, expectedDirection4, robot4))
                {
                    Console.WriteLine(" :: PASS:: ");
                }
                else
                {
                    Console.WriteLine(" :: FAIL ::");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: ");
                Console.WriteLine(exception.ToString());
            }

            // test 5
            try
            {
                Console.WriteLine("\nTest D: PLACE 5,0,WEST, MOVE, RIGHT, REPORT");
                Robot robot5 = new Robot();
                string[] commands3 =
                        {
                            "PLACE 0,5,WEST",
                            "MOVE",
                            "RIGHT",
                            "REPORT"
                        };
                RunRobotSimulation(robot5, commands3);
                int[] expectedPosition5 = { 0, 5};
                Direction expectedDirection5 = (Direction)Enum.Parse(typeof(Direction), "NORTH");

                if (CheckRobotPosition(expectedPosition5, expectedDirection5, robot5))
                {
                    Console.WriteLine(" :: PASS:: ");
                }
                else
                {
                    Console.WriteLine(" :: FAIL ::");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: ");
                Console.WriteLine(exception.ToString());
            }
        }
    }
}

