using Modelando.Shareds.Commands;

namespace Modelando.Shareds.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
