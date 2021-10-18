using HepsiSpace.Application.Enums;
using HepsiSpace.Application.Exceptions;
using System;

namespace HepsiSpace.Application.Entities
{
    public class Rover
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public string RoverCommand { get; set; }
        public Destination Destination { get; set; }

        public void SetRoverPosition(string roverPosition)
        {
            if (
                String.IsNullOrEmpty(roverPosition)
                ||
                roverPosition.Split(' ').Length != 3
                ||
                !int.TryParse(roverPosition.Split(' ')[0], out int x)
                ||
                !int.TryParse(roverPosition.Split(' ')[1], out int y)
                ||
                !Enum.IsDefined(typeof(Destination), roverPosition.Split(' ')[2].ToUpper())
                )
                throw new PositionException();

            LocationX = x;
            LocationY = y;
            Destination = (Destination)Enum.Parse(typeof(Destination), roverPosition.Split(' ')[2].ToUpper());
        }
    }
}
