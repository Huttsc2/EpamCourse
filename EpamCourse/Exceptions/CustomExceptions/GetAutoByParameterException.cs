namespace EpamCourse.Exceptions.CustomExceptions
{
    public class GetAutoByParameterException : Exception
    {
        public GetAutoByParameterException()
        {
        }

        public GetAutoByParameterException(string message)
            : base(message)
        {
        }

        public GetAutoByParameterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
