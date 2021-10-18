using HepsiSpace.Application.Entities;
using HepsiSpace.Application.Services;
using System;
using System.Linq;

namespace HepsiSpace.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("=====================");
            Console.Write("\nWelcome to HepsiSpace");
            Console.Write("\n=====================");

            try
            {
                Plateau plateau = new();
                Console.Write("\n\nPlatue Size : ");
                string plateauSize = Console.ReadLine();
                plateau.SetPlateauSize(plateauSize);

                while (true)
                {
                    try
                    {
                        Rover rover = new();

                        Console.Write("Rover Position : ");
                        string roverPosition = Console.ReadLine();
                        rover.SetRoverPosition(roverPosition);

                        Console.Write("Navigation : ");
                        string commands = Console.ReadLine();
                        rover.RoverCommand = commands;

                        plateau.AddRover(rover);
                    }
                    catch (Exception ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write($"\n{ex.Message}");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.Write("\nWould you like to add another rover? |Y/N|: ");
                    string isAddAnotherRover = Console.ReadLine();

                    if (isAddAnotherRover.ToUpper() != "Y")
                        break;
                }

                if (!Equals(plateau, null) || plateau.RoverList.Any())
                {
                    foreach (var roverItem in plateau.RoverList)
                    {
                        try
                        {
                            var rover = new ActionService(roverItem, plateau);
                            rover.Run(roverItem.RoverCommand);
                            string locationInfo = rover.GetLocationInfo();
                            Console.WriteLine($"\n{locationInfo}");
                        }
                        catch (Exception ex)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write($"\n{ex.Message}");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"\n{ex.Message}");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
