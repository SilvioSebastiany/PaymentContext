namespace PaymentContext.Shared.Commands
{
    //Interface para validar um comando
    public interface ICommand
    {
        void Validate();
    }
}