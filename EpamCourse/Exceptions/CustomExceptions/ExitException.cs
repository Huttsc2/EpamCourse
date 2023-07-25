namespace EpamCourse.Exceptions.CustomExceptions
{
    public class ExitException : Exception
    {
        public ExitException()
        {
        }

        public ExitException(string message)
            : base(message)
        {
        }

        public ExitException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
