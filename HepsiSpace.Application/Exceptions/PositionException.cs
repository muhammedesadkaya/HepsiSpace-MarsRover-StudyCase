using System;

namespace HepsiSpace.Application.Exceptions
{
    public class PositionException : Exception
    {
        public PositionException() : base("Please type two numbers and a letter(N, E, S, W) with one space character between them.")
        {

        }
    }
}
