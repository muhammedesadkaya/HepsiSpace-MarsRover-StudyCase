using HepsiSpace.Application.Abstracts;
using HepsiSpace.Application.Services;

namespace HepsiSpace.Application.Commands
{
    public class TurnRightCommand : ICommand
    {
        public void Execute(ActionService rover) => rover.TurnRight();
    }
}
