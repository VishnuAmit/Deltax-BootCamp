using System;

namespace MovieApp.Exceptions
{
    public class MovieValidationException : Exception
    {
        public MovieValidationException(string message) : base(message) { }
    }
}
