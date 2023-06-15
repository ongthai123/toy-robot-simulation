using ToyRobotSimulation.Interfaces;
using ToyRobotSimulation.Models.Constants;
using ToyRobotSimulation.Models.Enums;
using ToyRobotSimulation.Models.Models;

namespace ToyRobotSimulation.Test
{
    [TestFixture]
    public class Tests
    {
        private ToyRobot _toyRobot = new ToyRobot();
        private TableTop _tableTop = new TableTop
        {
            MaxX = 4,
            MaxY = 4,
        };

        [Test]
        public void TestXPositionWithinTheRange()
        {
            _toyRobot.Place(1, 1, (int)ToyRobotFacing.South);

            Assert.IsTrue(_toyRobot.CurrentPositionX >= 0 && _toyRobot.CurrentPositionX <= _tableTop.MaxX);
        }

        [Test]
        public void TestXPositionGreaterThanMaxRange()
        {
            _toyRobot.Place(5, 1, (int)ToyRobotFacing.South);

            Assert.IsTrue(_toyRobot.CurrentPositionX > _tableTop.MaxX);
        }

        [Test]
        public void TestXPositionSmallerThanMinRange()
        {
            _toyRobot.Place(-1, 1, (int)ToyRobotFacing.South);

            Assert.IsTrue(_toyRobot.CurrentPositionX < 0);
        }

        [Test]
        public void TestYPositionWithinTheRange()
        {
            _toyRobot.Place(1, 1, (int)ToyRobotFacing.South);

            Assert.IsTrue(_toyRobot.CurrentPositionY >= 0 && _toyRobot.CurrentPositionY <= _tableTop.MaxY);
        }

        [Test]
        public void TestYPositionGreaterThanMaxRange()
        {
            _toyRobot.Place(1, 8, (int)ToyRobotFacing.South);

            Assert.IsTrue(_toyRobot.CurrentPositionY > _tableTop.MaxY);
        }

        [Test]
        public void TestYPositionSmallerThanMinRange()
        {
            _toyRobot.Place(1, -3, (int)ToyRobotFacing.South);

            Assert.IsTrue(_toyRobot.CurrentPositionY < 0);
        }

        [Test]
        public void TestValidFacing()
        {
            _toyRobot.Place(0, 0, 1);

            Assert.IsTrue(Enum.IsDefined(typeof(ToyRobotFacing), _toyRobot.CurrentFacing));
        }

        [Test]
        public void TestInvalidFacing()
        {
            _toyRobot.Place(0, 0, 0);

            Assert.IsFalse(Enum.IsDefined(typeof(ToyRobotFacing), _toyRobot.CurrentFacing));
        }

        [Test]
        public void TestMoveToNorthWithValidY()
        {
            _toyRobot.Place(0, 3, (int)ToyRobotFacing.North);

            var nextYPosition = _toyRobot.CurrentPositionY + 1;

            _toyRobot.Move(_tableTop);

            Assert.IsTrue(nextYPosition == _toyRobot.CurrentPositionY);
        }

        [Test]
        public void TestMoveToNorthWithMaxY()
        {
            _toyRobot.Place(0, 4, (int)ToyRobotFacing.North);

            var nextYPosition = _toyRobot.CurrentPositionY + 1;

            _toyRobot.Move(_tableTop);

            Assert.IsFalse(nextYPosition == _toyRobot.CurrentPositionY);
        }

        [Test]
        public void TestMoveToEastWithValidX()
        {
            _toyRobot.Place(0, 4, (int)ToyRobotFacing.East);

            var nextXPosition = _toyRobot.CurrentPositionX + 1;

            _toyRobot.Move(_tableTop);

            Assert.IsTrue(nextXPosition == _toyRobot.CurrentPositionX);
        }

        [Test]
        public void TestMoveToEastWithMaxX()
        {
            _toyRobot.Place(4, 4, (int)ToyRobotFacing.East);

            var nextXPosition = _toyRobot.CurrentPositionX + 1;

            _toyRobot.Move(_tableTop);

            Assert.IsFalse(nextXPosition == _toyRobot.CurrentPositionX);
        }

        [Test]
        public void TestMoveToSouthWithValidY()
        {
            _toyRobot.Place(4, 4, (int)ToyRobotFacing.South);

            var nextYPosition = _toyRobot.CurrentPositionY - 1;

            _toyRobot.Move(_tableTop);

            Assert.IsTrue(nextYPosition == _toyRobot.CurrentPositionY);
        }

        [Test]
        public void TestMoveToSouthWithMinY()
        {
            _toyRobot.Place(4, 0, (int)ToyRobotFacing.South);

            var nextYPosition = _toyRobot.CurrentPositionY - 1;

            _toyRobot.Move(_tableTop);

            Assert.IsFalse(nextYPosition == _toyRobot.CurrentPositionY);
        }

        [Test]
        public void TestMoveToWestWithValidX()
        {
            _toyRobot.Place(4, 0, (int)ToyRobotFacing.West);

            var nextXPosition = _toyRobot.CurrentPositionX - 1;

            _toyRobot.Move(_tableTop);

            Assert.IsTrue(nextXPosition == _toyRobot.CurrentPositionX);
        }

        [Test]
        public void TestMoveToWestWithMinX()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.West);

            var nextXPosition = _toyRobot.CurrentPositionX - 1;

            _toyRobot.Move(_tableTop);

            Assert.IsFalse(nextXPosition == _toyRobot.CurrentPositionX);
        }

        [Test]
        public void TestTurnLeftFromNorth()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.North);

            _toyRobot.TurnLeft();

            Assert.IsTrue((int)ToyRobotFacing.West == _toyRobot.CurrentFacing);
        }

        [Test]
        public void TestTurnRightFromNorth()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.North);

            _toyRobot.TurnRight();

            Assert.IsTrue((int)ToyRobotFacing.East == _toyRobot.CurrentFacing);
        }

        [Test]
        public void TestTurnLeftFromEast()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.East);

            _toyRobot.TurnLeft();

            Assert.IsTrue((int)ToyRobotFacing.North == _toyRobot.CurrentFacing);
        }

        [Test]
        public void TestTurnRightFromEast()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.East);

            _toyRobot.TurnRight();

            Assert.IsTrue((int)ToyRobotFacing.South == _toyRobot.CurrentFacing);
        }

        [Test]
        public void TestTurnLeftFromSouth()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.South);

            _toyRobot.TurnLeft();

            Assert.IsTrue((int)ToyRobotFacing.East == _toyRobot.CurrentFacing);
        }

        [Test]
        public void TestTurnRightFromSouth()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.South);

            _toyRobot.TurnRight();

            Assert.IsTrue((int)ToyRobotFacing.West == _toyRobot.CurrentFacing);
        }

        [Test]
        public void TestTurnLeftFromWest()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.West);

            _toyRobot.TurnLeft();

            Assert.IsTrue((int)ToyRobotFacing.South == _toyRobot.CurrentFacing);
        }

        [Test]
        public void TestTurnRightFromWest()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.West);

            _toyRobot.TurnRight();

            Assert.IsTrue((int)ToyRobotFacing.North == _toyRobot.CurrentFacing);
        }

        [Test]
        public void TestMoveFrom00NorthTo01North()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.North);

            _toyRobot.Move(_tableTop);

            var toyAt01North = new ToyRobot();

            toyAt01North.Place(0, 1, (int)ToyRobotFacing.North);

            Assert.IsTrue(_toyRobot.Report() == toyAt01North.Report());
        }

        [Test]
        public void TestMoveFrom00NorthTo00West()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.North);

            _toyRobot.TurnLeft();

            var toyAt00West = new ToyRobot();

            toyAt00West.Place(0, 0, (int)ToyRobotFacing.West);

            Assert.IsTrue(_toyRobot.Report() == toyAt00West.Report());
        }

        [Test]
        public void TestMoveFrom12EastTo33North()
        {
            _toyRobot.Place(1, 2, (int)ToyRobotFacing.East);

            _toyRobot.Move(_tableTop);

            _toyRobot.Move(_tableTop);

            _toyRobot.TurnLeft();

            _toyRobot.Move(_tableTop);

            var toyAt33North = new ToyRobot();

            toyAt33North.Place(3, 3, (int)ToyRobotFacing.North);

            Assert.IsTrue(_toyRobot.Report() == toyAt33North.Report());
        }

        [Test]
        public void TestMoveFrom00NorthTo44South()
        {
            _toyRobot.Place(0, 0, (int)ToyRobotFacing.North);

            _toyRobot.Move(_tableTop);

            _toyRobot.Move(_tableTop);

            _toyRobot.TurnRight();

            _toyRobot.Move(_tableTop);

            _toyRobot.Move(_tableTop);

            _toyRobot.TurnLeft();

            _toyRobot.Move(_tableTop);

            _toyRobot.Move(_tableTop);

            _toyRobot.TurnRight();

            _toyRobot.Move(_tableTop);

            _toyRobot.Move(_tableTop);

            _toyRobot.TurnRight();

            var toyAt44South = new ToyRobot();

            toyAt44South.Place(4, 4, (int)ToyRobotFacing.South);

            Assert.IsTrue(_toyRobot.Report() == toyAt44South.Report());
        }
    }
}