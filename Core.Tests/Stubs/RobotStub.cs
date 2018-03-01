using System;
using System.Collections.Generic;
using Robots.Core.SDK;

namespace Robots.Core.Tests.Stubs
{
    public class RobotStub : IRobot
    {
        public readonly List<String> Log = new List<String>();

        public void Beep()
        {
            Log.Add("Beep");
        }

        public void Move(double distance)
        {
            Log.Add(String.Format("Move {0}", distance));
        }

        public void Turn(double angle)
        {
            Log.Add(String.Format("Turn {0}", angle));
        }
    }
}
