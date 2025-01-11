

using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        // Red, Green, Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService()); 
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "99999999999";
            command.Email = "silvio.sebastiany@herval.com.br";
            command.BarCode = "123456789";
            command.BoletoNumber = "123456789";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "WAYNE CORP";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDucumentType.CPF;
            command.PayerEmail = "batman@dc.com";
            command.Street = "asdas";
            command.Number = "as";
            command.Neighborhood = "dddf";
            command.City = "asdfsd";
            command.State = "adfse";
            command.Country = "sdfsdsf";
            command.ZipCode = "187571571";

            handler.Handle(command);
            Assert.AreEqual(false, handler.IsValid);
        }

    }
    
}