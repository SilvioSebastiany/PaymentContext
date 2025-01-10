using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers
{
    //Interface para o manipulador de comandos
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
