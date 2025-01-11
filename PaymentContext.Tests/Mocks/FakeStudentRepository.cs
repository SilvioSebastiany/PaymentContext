using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
            
        }

        public bool DocumentExists(string document)
        {
            if (document == "99999999999")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "silvio@teste.com.br")
                return true;

            return false;
        }
    }
}