using HepsiSpace.Application.Entities;
using HepsiSpace.Application.Exceptions;
using NUnit.Framework;

namespace HepsiSpace.Test
{
    public class PlateauTest
    {
        [Test]
        public void Plateau_SetPlateauSize()
        {
            Plateau plateau = new();
            plateau.SetPlateauSize("1 4");
            Assert.AreEqual(1, plateau.PlateauX);
            Assert.AreEqual(4, plateau.PlateauY);
        }

        [Test]
        public void Plateau_AddRover()
        {
            Plateau plateau = new();
            Rover rover = new();

            plateau.SetPlateauSize("1 1");
            rover.SetRoverPosition("0 0 W");
            plateau.AddRover(rover);

            Assert.AreEqual(1, plateau.RoverList.Count);
        }

        [Test]
        public void Plateau_AddRover_PlateauSizeOverException()
        {
            Plateau plateau = new();
            Rover rover = new();

            plateau.SetPlateauSize("1 1");
            rover.SetRoverPosition("2 9 N");

            Assert.Throws(typeof(PlateauSizeException), () => plateau.AddRover(rover));
        }

        [Test]
        [TestCase("0 0")]
        [TestCase("-1 -1")]
        public void Plateau_SetPlateauSize_InvalidPlateauSize(string input)
        {
            Plateau plateau = new();
            Assert.Throws(typeof(PlateauSizeException), () => plateau.SetPlateauSize(input));
        }
    }
}
