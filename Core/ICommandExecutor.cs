using Robots.Core.SDK;

namespace Robots.Core
{
    public interface ICommandExecutor
    {
        void Execute( IRobot robot, Command command );
    }
}
