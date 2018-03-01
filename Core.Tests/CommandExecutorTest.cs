using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots.Core.Tests.Stubs;

namespace Robots.Core.Tests
{
    [TestClass]
    public class CommandExecutorTest
    {
        private ICommandExecutor _executor;

        [TestInitialize]
        public void Init()
        {
            _executor = new CommandExecutor();
        }

        [TestMethod]
        public void Execute_Beep_Success()
        {
            var robot = new RobotStub();

            _executor.Execute(robot, new Command(Commands.Beep));

            Assert.AreEqual("Beep", robot.Log[0]);
        }

        [TestMethod]
        public void Execute_Move_Success()
        {
            var robot = new RobotStub();

            _executor.Execute(robot, new Command(Commands.Move, new List<object>() { 1.234 }));

            Assert.AreEqual("Move 1,234", robot.Log[0]);
        }

        [TestMethod]
        public void Execute_Turn_Success()
        {
            var robot = new RobotStub();

            _executor.Execute(robot, new Command(Commands.Turn, new List<object>() { 2.56 }));

            Assert.AreEqual("Turn 2,56", robot.Log[0]);
        }

        [TestMethod]
        public void Execute_MoveBeepTurn_Success()
        {
            var robot = new RobotStub();

            _executor.Execute(robot, new Command(Commands.Move, new List<object>() { 5d }));
            _executor.Execute(robot, new Command(Commands.Beep));
            _executor.Execute(robot, new Command(Commands.Turn, new List<object>() { 6d }));

            Assert.AreEqual("Move 5", robot.Log[0]);
            Assert.AreEqual("Beep", robot.Log[1]);
            Assert.AreEqual("Turn 6", robot.Log[2]);
        }
    }
}
