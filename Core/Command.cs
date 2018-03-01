using System;
using System.Collections.Generic;
using Robots.Core.SDK;

namespace Robots.Core
{
    public class Command
    {
        public Commands Type { get; private set; }
        public List<Object> Parameters { get; private set; }
        public IRobot Robot { get; set; }

        public Command(Commands type, List<Object> parameters = null)
        {
            Type = type;
            Parameters = parameters;
        }
    }
}