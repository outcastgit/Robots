using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots.Core.SDK;
using Robots.Core.Tests.Stubs;

namespace Robots.Core.Tests
{
    [TestClass]
    public class RobotHandlerTest
    {
        [TestMethod]
        public void SendCommand_SendNull_Exception()
        {
            var executor = new CommandExecutorStub();
            var handler = new RobotHandler(executor);

            var robot = new RobotStub();

            Assert.ThrowsException<ArgumentNullException>(() => { handler.SendCommand(null, new Command(Commands.Beep)); });
            Assert.ThrowsException<ArgumentNullException>(() => { handler.SendCommand(robot, null); });
        }

        [TestMethod]
        public void SendCommand_Normal_Success()
        {
            var executor = new CommandExecutorStub();
            var handler = new RobotHandler(executor);
            var robot = new RobotStub();

            handler.SendCommand(robot, new Command(Commands.Beep));
            Assert.AreEqual(String.Format("{0}-Beep", robot.GetHashCode()), executor.Log[0]);

            handler.SendCommand(robot, new Command(Commands.Move, new List<object>() { 1d }));
            Assert.AreEqual(String.Format("{0}-Move", robot.GetHashCode()), executor.Log[1]);
        }

        [TestMethod]
        public void RepeatCommand_Normal_Success()
        {
            var executor = new CommandExecutorStub();
            var handler = new RobotHandler(executor);
            var robot = new RobotStub();

            handler.SendCommand(robot, new Command(Commands.Beep));
            handler.SendCommand(robot, new Command(Commands.Turn, new List<object>() { 1d }));
            handler.SendCommand(robot, new Command(Commands.Move, new List<object>() { 1d }));

            var robots = new List<IRobot>()
            {
                new RobotStub(),
                new RobotStub()
            };

            handler.RepeatCommands(robots);

            Assert.AreEqual(String.Format("{0}-Move", robot.GetHashCode()), executor.Log[2]);

            Assert.AreEqual(String.Format("{0}-Beep", robots[0].GetHashCode()), executor.Log[3]);
            Assert.AreEqual(String.Format("{0}-Turn", robots[0].GetHashCode()), executor.Log[4]);
            Assert.AreEqual(String.Format("{0}-Move", robots[0].GetHashCode()), executor.Log[5]);

            Assert.AreEqual(String.Format("{0}-Beep", robots[1].GetHashCode()), executor.Log[6]);
            Assert.AreEqual(String.Format("{0}-Turn", robots[1].GetHashCode()), executor.Log[7]);
            Assert.AreEqual(String.Format("{0}-Move", robots[1].GetHashCode()), executor.Log[8]);
        }
    }
}
