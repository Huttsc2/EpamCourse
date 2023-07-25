namespace EpamCourse.Object_Oriented_Design_Principles.Commands
{
    public interface ICommand
    {
        void Execute();
        void SetArguments(string args);
    }


}
