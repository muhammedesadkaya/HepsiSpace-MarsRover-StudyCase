using HepsiSpace.Application.Entities;
using HepsiSpace.Application.Enums;
using HepsiSpace.Application.Exceptions;
using HepsiSpace.Application.Services;
using NUnit.Framework;

namespace HepsiSpace.Test
{
    public class RoverTest
    {
        [Test]
        [TestCase("1 2 N", "L", "1 2 W")]
        [TestCase("1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase("3 3 E", "MMRMMRMRRM", "5 1 E")]
        [TestCase("0 0 N", "MMMMMRMMMMML", "5 5 N")]
        [TestCase("0 0 N", "RLRLRLRLRLRL", "0 0 N")]
        public void Rover_TurnLeft(string input, string commands, string output)
        {
            Plateau plateau = new();
            Rover rover = new();

            plateau.SetPlateauSize("5 5");
            rover.SetRoverPosition(input);
            rover.RoverCommand = commands;

            var roverAction = new ActionService(rover, plateau);
            roverAction.Run(commands);

            Assert.AreEqual(output, roverAction.GetLocationInfo());
        }

        [Test]
        [TestCase("1 2 N", "R", "1 2 E")]
        public void Rover_TurnRight(string input, string commands, string output)
        {
            Plateau plateau = new();
            Rover rover = new();

            plateau.SetPlateauSize("5 5");
            rover.SetRoverPosition(input);
            rover.RoverCommand = commands;

            var roverAction = new ActionService(rover, plateau);
            roverAction.Run(commands);

            Assert.AreEqual(output, roverAction.GetLocationInfo());
        }

        [Test]
        [TestCase("1 2 N", "M", "1 3 N")]
        public void Rover_Move(string input, string commands, string output)
        {
            Plateau plateau = new();
            Rover rover = new();

            plateau.SetPlateauSize("5 5");
            rover.SetRoverPosition(input);
            rover.RoverCommand = commands;

            var roverAction = new ActionService(rover, plateau);
            roverAction.Run(commands);

            Assert.AreEqual(output, roverAction.GetLocationInfo());
        }

        [Test]
        public void Rover_SetRoverPosition()
        {
            Rover rover = new();
            rover.SetRoverPosition("1 5 S");

            Assert.AreEqual(1, rover.LocationX);
            Assert.AreEqual(5, rover.LocationY);
            Assert.AreEqual(Destination.S, rover.Destination);
        }

        [Test]
        public void Rover_IsDeported()
        {
            Plateau plateau = new();
            Rover rover = new();

            plateau.SetPlateauSize("5 5");
            rover.SetRoverPosition("1 2 N");
            rover.RoverCommand = "LMLMLMMMMMMLMM";

            var roverAction = new ActionService(rover, plateau);

            Assert.Throws<PlateauSizeException>(() => roverAction.Run("LMLMLMMMMMMLMM"));
        }

        [Test]
        public void Rover_SetRoverPosition_PositionException()
        {
            Rover rover = new();

            Assert.Throws(typeof(PositionException), () => rover.SetRoverPosition("5 5"));
        }
    }
}
