using ToyRobotSimulation.Interfaces;
using ToyRobotSimulation.Models.Constants;
using ToyRobotSimulation.Models.Enums;
using ToyRobotSimulation.Models.Models;

namespace ToyRobotSimulation.BusinessLogics
{
    public class Manager : IManager
    {
        private readonly TableTop _tableTop;

        private ToyRobot toyRobot;

        public Manager(TableTop tableTop)
        {

            _tableTop = tableTop;

        }

        public void Run()
        {
            toyRobot = new ToyRobot();

            while (true)
            {
                AskForCommand();
            }
        }

        private void AskForCommand()
        {
            Console.WriteLine("Please input command: ");

            var command = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(command))
                return;

            command = command.ToUpper().Trim();

            ProcessCommand(command);
        }

        private void ProcessCommand(string command)
        {
            //Place toy until it is valid
            if (command.StartsWith(Commands.PLACE))
            {
                toyRobot = ProcessPlacingCommand(command);
                return;
            }

            var isToyNotOnTheTable = toyRobot == null
                || (toyRobot.CurrentFacing != (int)ToyRobotFacing.North
                && toyRobot.CurrentFacing != (int)ToyRobotFacing.East
                && toyRobot.CurrentFacing != (int)ToyRobotFacing.South
                && toyRobot.CurrentFacing != (int)ToyRobotFacing.West);

            //Proceed next commands if toy position is valid
            if (isToyNotOnTheTable)
            {
                Console.WriteLine("Please set the toy position before moving it.");
                return;
            }

            if (command == Commands.MOVE)
            {
                toyRobot.Move(_tableTop);
            }
            else if (command == Commands.LEFT)
            {
                toyRobot.TurnLeft();
            }
            else if (command == Commands.RIGHT)
            {
                toyRobot.TurnRight();
            }
            else if (command == Commands.REPORT)
            {
                Console.WriteLine(toyRobot.Report());
            }
            else
            {
                Console.WriteLine("\nCommand is invalid.\n");
            }
        }

        private ToyRobot ProcessPlacingCommand(string command)
        {
            var hasValidPlace = true;

            try
            {
                var position = command.Substring(6).Split(",");

                var x = Convert.ToInt16(position[0].Trim());

                var y = Convert.ToInt16(position[1].Trim());

                if (x < 0 || y < 0 || x > 4 || y > 4)
                {
                    hasValidPlace = false;
                }

                var facing = 0;

                switch (position[2].Trim())
                {
                    case "NORTH":
                        facing = (int)ToyRobotFacing.North;
                        break;
                    case "EAST":
                        facing = (int)ToyRobotFacing.East;
                        break;
                    case "SOUTH":
                        facing = (int)ToyRobotFacing.South;
                        break;
                    case "WEST":
                        facing = (int)ToyRobotFacing.West;
                        break;
                    default:
                        hasValidPlace = false;
                        break;
                }

                if (!hasValidPlace)
                {
                    Console.WriteLine("\nPlacing position is invalid.\n");

                    return null;
                }

                Console.WriteLine("\nA new position has been placed.\n");

                var result = new ToyRobot();

                result.Place(x, y, facing);

                return result;
            }
            catch
            {
                Console.WriteLine("\nPlacing command is invalid.\n");

                return null;
            }
        }
    }
}