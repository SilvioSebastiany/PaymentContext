namespace PaymentContext.Shared.Commands
{
    //Classe para retornar o resultado de um comando 
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public CommandResult()
        {
        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

    }
}  

