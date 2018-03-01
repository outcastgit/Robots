using System;
using Robots.Core.SDK;

namespace Robots.Core
{
    public class CommandExecutor : ICommandExecutor
    {
        public void Execute(IRobot robot, Command command)
        {
            switch (command.Type)
            {
                case Commands.Beep:
                    robot.Beep();
                    break;

                case Commands.Move:
                    robot.Move((double)command.Parameters[0]);
                    break;

                case Commands.Turn:
                    robot.Turn((double)command.Parameters[0]);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
