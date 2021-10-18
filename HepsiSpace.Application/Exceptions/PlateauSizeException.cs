using System;

namespace HepsiSpace.Application.Exceptions
{
    public class PlateauSizeException : Exception
    {

        public PlateauSizeException() : base("Plateau size exceeded.")
        {

        }

        public PlateauSizeException(string message) : base(message)
        {

        }
    }
}
