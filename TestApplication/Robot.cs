using System;
using Robots.Core.SDK;

namespace TestApplication
{
    public class Robot : IRobot
    {
        public String Name { get; private set; }

        public Robot(String name)
        {
            Name = name;
        }

        public void Beep()
        {
            Console.WriteLine("{0} Beep", Name);
        }

        public void Move(double distance)
        {
            Console.WriteLine("{0} Move {1}", Name, distance);
        }

        public void Turn(double angle)
        {
            Console.WriteLine("{0} Turn {1}", Name, angle);
        }
    }
}
