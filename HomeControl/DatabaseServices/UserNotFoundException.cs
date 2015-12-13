using System;

namespace HomeControl.DatabaseServices
{
    internal class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message)
            :base(message)
        {
        }
    }
}