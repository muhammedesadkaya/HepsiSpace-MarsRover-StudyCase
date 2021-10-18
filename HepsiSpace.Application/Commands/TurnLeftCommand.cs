using HepsiSpace.Application.Abstracts;
using HepsiSpace.Application.Services;

namespace HepsiSpace.Application.Commands
{
    public class TurnLeftCommand : ICommand
    {
        public void Execute(ActionService rover) => rover.TurnLeft();
    }
}
