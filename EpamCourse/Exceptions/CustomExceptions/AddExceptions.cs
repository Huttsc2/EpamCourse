﻿namespace EpamCourse.Exceptions.CustomExceptions
{
    public class AddException : Exception
    {
        public AddException()
        {
        }

        public AddException(string message)
            : base(message)
        {
        }

        public AddException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
