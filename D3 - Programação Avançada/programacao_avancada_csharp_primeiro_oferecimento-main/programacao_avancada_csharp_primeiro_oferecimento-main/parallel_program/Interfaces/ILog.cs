using parallel_program.Models;

namespace parallel_program.Interfaces
{
    internal interface ILog
    {
        void RegisterAccess(User user);
    }
}
