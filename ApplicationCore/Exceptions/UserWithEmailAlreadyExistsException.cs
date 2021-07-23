using System;

namespace ApplicationCore.Exceptions
{
    public class UserWithEmailAlreadyExistsException : Exception
    {
        public UserWithEmailAlreadyExistsException(string message) : base(message)
        {
        }
    }
}