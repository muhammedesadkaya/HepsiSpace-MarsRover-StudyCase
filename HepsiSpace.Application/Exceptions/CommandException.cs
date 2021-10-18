using System;

namespace HepsiSpace.Application.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException() : base("Invalid rover command. Command letter should be one of L,R or M.")
        {

        }
    }
}
