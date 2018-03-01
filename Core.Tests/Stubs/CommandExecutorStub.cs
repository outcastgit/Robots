using System;
using System.Collections.Generic;
using Robots.Core.SDK;

namespace Robots.Core.Tests.Stubs
{
    public class CommandExecutorStub : ICommandExecutor
    {
        public readonly List<String> Log = new List<String>();

        public void Execute(IRobot robot, Command command)
        {
            Log.Add(String.Format( "{0}-{1}", robot.GetHashCode(), command.Type.ToString()));
        }
    }
}
