using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories
{
    //Interface para o repositório de estudantes
    public interface IStudentRepository
    {   
        bool DocumentExists(string document);
        bool EmailExists(string email);
        void CreateSubscription(Student student);
    }
}