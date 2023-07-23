namespace EpamCourse.Exceptions.CustomExceptions
{
    public class UpdateAutoException : Exception
    {
        public UpdateAutoException()
        {
        }

        public UpdateAutoException(string message)
            : base(message)
        {
        }

        public UpdateAutoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
