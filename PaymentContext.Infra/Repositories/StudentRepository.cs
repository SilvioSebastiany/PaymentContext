using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Infra.Repositories
{
    //Implementação do repositório de estudantes
    public class StudentRepository : IStudentRepository
    {
        public bool DocumentExists(string document)
        {
            // Implementar a lógica para verificar se o documento já está cadastrado
            // Exemplo: consultar o banco de dados
            return false;
        }
        public bool EmailExists(string email)
        {
            // Implementar a lógica para verificar se o email já está cadastrado
            // Exemplo: consultar o banco de dados
            return false;
        }
        public void CreateSubscription(Student student)
        {
            // Implementar a lógica para criar uma nova assinatura para o estudante
            // Exemplo: salvar no banco de dados
        }
    }
}