using System;
using System.Collections.Generic;
using Robots.Core.SDK;

namespace Robots.Core
{
    public class RobotHandler
    {
        private List<Command> _commands;
        private readonly ICommandExecutor _executor;

        public RobotHandler(ICommandExecutor executor)
        {
            _executor = executor;
            _commands = new List<Command>();
        }

        public void SendCommand(IRobot robot, Command command)
        {
            if(robot == null) throw new ArgumentNullException("robot");
            if(command == null) throw new ArgumentNullException("command");

            _executor.Execute(robot, command);

            _commands.Add(command);
        }

        public void RepeatCommands(List<IRobot> robots)
        {
            if (robots == null) throw new ArgumentNullException("robots");

            foreach (var robot in robots)
            {
                foreach (var command in _commands)
                {
                    _executor.Execute(robot, command);
                }
            }
        }
    }
}