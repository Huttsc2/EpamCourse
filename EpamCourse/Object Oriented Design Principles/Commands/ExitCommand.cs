using EpamCourse.Exceptions.CustomExceptions;

namespace EpamCourse.Object_Oriented_Design_Principles.Commands
{
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            throw new ExitException("The program is stopped");
        }

        public void SetArguments(string args) { }
    }
}
