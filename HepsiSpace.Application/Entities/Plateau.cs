using HepsiSpace.Application.Exceptions;
using System;
using System.Collections.Generic;

namespace HepsiSpace.Application.Entities
{
    public class Plateau
    {
        public int PlateauX { get; private set; }
        public int PlateauY { get; private set; }
        public List<Rover> RoverList { get; private set; }

        public Plateau()
        {
            RoverList = new();
        }

        public void SetPlateauSize(string size)
        {
            if (
                String.IsNullOrEmpty(size)
                ||
                size.Split(' ').Length != 2
                ||
                !int.TryParse(size.Split(' ')[0], out int x)
                ||
                !int.TryParse(size.Split(' ')[1], out int y)
                ||
                x <= 0
                ||
                y <= 0
                )
                throw new PlateauSizeException("Please type two numbers (except 0) with one space character between them.");

            PlateauX = x;
            PlateauY = y;
        }

        public void AddRover(Rover rover)
        {
            if (Equals(rover, null) || rover.LocationX > PlateauX || rover.LocationY > PlateauY)
                throw new PlateauSizeException();

            RoverList.Add(rover);
        }
    }
}
