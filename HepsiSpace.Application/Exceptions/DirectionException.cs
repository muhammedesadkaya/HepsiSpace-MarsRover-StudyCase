using System;

namespace HepsiSpace.Application.Exceptions
{
    public class DirectionException : Exception
    {
        public DirectionException() : base("Invalid direction. Direction should be one of N, E, S or W.")
        {

        }
    }
}
