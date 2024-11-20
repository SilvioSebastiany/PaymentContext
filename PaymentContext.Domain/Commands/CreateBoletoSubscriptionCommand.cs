using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
        
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }   
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDucumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(FirstName, "FirstName", "First name is required")
                .IsNotNullOrEmpty(LastName, "LastName", "Last name is required")
                .IsNotNullOrEmpty(Document, "Document", "Document is required")
                .IsEmail(Email, "Email", "Invalid email")
                .IsNotNullOrEmpty(BarCode, "BarCode", "Bar code is required")
                .IsNotNullOrEmpty(BoletoNumber, "BoletoNumber", "Boleto number is required")
                .IsGreaterThan(Total, 0, "Total", "Total must be greater than zero")
                .IsGreaterThan(TotalPaid, 0, "TotalPaid", "Total paid must be greater than zero")
                .IsNotNullOrEmpty(Payer, "Payer", "Payer is required")
                .IsNotNullOrEmpty(PayerDocument, "PayerDocument", "Payer document is required")
            );
        }
    }
}