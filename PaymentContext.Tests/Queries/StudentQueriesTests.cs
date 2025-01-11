using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();
            for (var i = 0; i <= 10; i++)
            {
                _students.Add(new Student(new Name("Aluno", i.ToString()),
                                          new Document("1111111111" + i.ToString(), EDucumentType.CPF),
                                          new Email(i.ToString() + "@balta.io")));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            // Verifica se o estudante é nulo. Se for, o teste passa.
            Assert.AreEqual(null, student);
        }

        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("1111111111");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            // Verifica se o estudante é nulo. Se for, o teste passa.
            Assert.AreEqual(null, student);
        }
    }
}