using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulation.Models.Constants;
using ToyRobotSimulation.Models.Enums;

namespace ToyRobotSimulation.Models.Models
{
    public class ToyRobot
    {
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public int CurrentFacing { get; set; }

        public void Place(int x, int y, int facing)
        {
            CurrentPositionX = x;
            CurrentPositionY = y;
            CurrentFacing = facing;
        }

        public void Move(TableTop tableTop)
        {
            switch (CurrentFacing)
            {
                case (int)ToyRobotFacing.North:
                    if (CurrentPositionY < tableTop.MaxY) CurrentPositionY++;
                    break;
                case (int)ToyRobotFacing.East:
                    if (CurrentPositionX < tableTop.MaxX) CurrentPositionX++;
                    break;
                case (int)ToyRobotFacing.South:
                    if (CurrentPositionY > 0) CurrentPositionY--;
                    break;
                case (int)ToyRobotFacing.West:
                    if (CurrentPositionX > 0) CurrentPositionX--;
                    break;
                default:
                    break;
            }
        }

        public void TurnLeft()
        {
            CurrentFacing--;

            if (((int)CurrentFacing) < 1)
            {
                CurrentFacing = (int)ToyRobotFacing.West;
            }
        }

        public void TurnRight()
        {
            CurrentFacing++;

            if (((int)CurrentFacing) > 4)
            {
                CurrentFacing = (int)ToyRobotFacing.North;
            }
        }

        public string Report()
        {
            return $"{CurrentPositionX}, {CurrentPositionY}, {Enum.GetName(typeof(ToyRobotFacing), CurrentFacing)}";
        }
    }
}
