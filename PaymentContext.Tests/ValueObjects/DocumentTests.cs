using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDucumentType.CNPJ);
            Assert.IsTrue(!doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenCNPJIsValid()
        {
            var doc = new Document("73520256000101", EDucumentType.CNPJ);
            Assert.IsTrue(doc.IsValid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDucumentType.CPF);
            Assert.IsTrue(!doc.IsValid);
        }
        
        [TestMethod]
        [DataTestMethod]
        [DataRow("12345678911")]
        [DataRow("02958857000")]
        [DataRow("12345678913")]
        public void ShouldReturnSucessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDucumentType.CPF);
            Assert.IsTrue(doc.IsValid);
        }
    }
}