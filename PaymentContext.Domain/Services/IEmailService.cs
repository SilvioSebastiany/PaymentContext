namespace PaymentContext.Domain.Services
{
    //Interface para envio de e-mail
    public interface IEmailService
    {
        void Send(string to, string email, string subject, string body);
    }
}