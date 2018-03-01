using System.Collections.Generic;
using Robots.Core;
using Robots.Core.SDK;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommandExecutor executor = new CommandExecutor();

            var handler = new RobotHandler(executor);
            var robot = new Robot("Bob");

            handler.SendCommand(robot, new Command(Commands.Beep));
            handler.SendCommand(robot, new Command(Commands.Turn, new List<object>() { 2.5 }));
            handler.SendCommand(robot, new Command(Commands.Beep));
            handler.SendCommand(robot, new Command(Commands.Move, new List<object>() { 3.54 }));

            var robots = new List<IRobot>()
            {
                new Robot( "Billy" ),
                new Robot( "John" ),
                new Robot( "Petya" ),
            };

            handler.RepeatCommands( robots );
        }
    }
}
