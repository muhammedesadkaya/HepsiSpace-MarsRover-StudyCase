using HepsiSpace.Application.Services;

namespace HepsiSpace.Application.Abstracts
{
    public interface ICommand
    {
        void Execute(ActionService rover);
    }
}
