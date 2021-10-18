using HepsiSpace.Application.Abstracts;
using HepsiSpace.Application.Commands;
using HepsiSpace.Application.Entities;
using HepsiSpace.Application.Enums;
using HepsiSpace.Application.Exceptions;
using System.Collections.Generic;

namespace HepsiSpace.Application.Services
{
    public class ActionService
    {
        private readonly Rover _rover;
        private readonly Plateau _plateau;
        public ActionService(Rover rover, Plateau plateau)
        {
            _rover = rover;
            _plateau = plateau;
        }

        /// <summary>
        /// Komut'a göre yapacağı command imzası.
        /// </summary>
        private readonly Dictionary<char, ICommand> _commands = new()
        {
            ['M'] = new MoveCommand(),
            ['L'] = new TurnLeftCommand(),
            ['R'] = new TurnRightCommand()
        };

        /// <summary>
        /// Rover'ın pusula yönünde dönme ve hareket etme işlemlerini execute eder.
        /// </summary>
        /// <param name="commands">LMLMLMLMM</param>
        public void Run(string commands)
        {
            var commandCharList = commands.ToCharArray();
            foreach (var commandChar in commandCharList)
            {
                _commands.TryGetValue(commandChar, out ICommand command);
                if (!Equals(command, null))
                {
                    if (commandChar == 'M' && IsDeported(_rover))
                        command.Execute(this);
                    else
                        command.Execute(this);
                }
                else
                    throw new CommandException();
            }
        }

        /// <summary>
        /// Rover pusula yönünde (x,y) eksesine göre hareket ettiğine entity değeri güncellenir.
        /// </summary>
        public void Move()
        {
            switch (_rover.Destination)
            {
                case Destination.N:
                    _rover.LocationY++;
                    break;
                case Destination.S:
                    _rover.LocationY--;
                    break;
                case Destination.W:
                    _rover.LocationX--;
                    break;
                case Destination.E:
                    _rover.LocationX++;
                    break;
            }
        }

        /// <summary>
        /// Rover sola döneceği zaman pusula yönünde nereye bakacağını değiştirir.
        /// </summary>
        public void TurnLeft()
        {
            _rover.Destination = _rover.Destination switch
            {
                Destination.N => Destination.W,
                Destination.E => Destination.N,
                Destination.S => Destination.E,
                Destination.W => Destination.S,
                _             => throw new DirectionException(),
            };
        }

        /// <summary>
        /// Rover sağa döneceği zaman pusula yönünde nereye bakacağını değiştirir.
        /// </summary>
        public void TurnRight()
        {
            _rover.Destination = _rover.Destination switch
            {
                Destination.N => Destination.E,
                Destination.E => Destination.S,
                Destination.S => Destination.W,
                Destination.W => Destination.N,
                _             => throw new DirectionException(),
            };
        }

        /// <summary>
        /// Rover'ın o an ki konumunu ve baktığı pusula yönünü verir.
        /// </summary>
        /// <returns>Rover'ın X,Y ve Baktığı yönün koordinatlarını verir.</returns>
        public string GetLocationInfo()
        {
            return $"{_rover.LocationX} {_rover.LocationY} {_rover.Destination.ToString().ToUpper()}";
        }

        /// <summary>
        /// Rover eğer plateau alanından çıkmaya çalışırsa kontrol eder ve exception fırlatır.
        /// </summary>
        /// <returns>true</returns>
        private bool IsDeported(Rover rover)
        {
            if (
                (rover.Destination == Destination.N && (rover.LocationY == _plateau.PlateauY))
                ||
                (rover.Destination == Destination.S && (rover.LocationY == 0))
                ||
                (rover.Destination == Destination.E && (rover.LocationX == _plateau.PlateauX))
                ||
                (rover.Destination == Destination.W && (rover.LocationX == 0))
                )
                throw new PlateauSizeException();

            return true;
        }
    }
}
