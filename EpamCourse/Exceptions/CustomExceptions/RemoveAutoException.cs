namespace EpamCourse.Exceptions.CustomExceptions
{
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException()
        {
        }

        public RemoveAutoException(string message)
            : base(message)
        {
        }

        public RemoveAutoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
