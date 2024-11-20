using System.Data;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        
        public string TransactionCode { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }   
        public string Total { get; set; }
        public string TotalPaid { get; set; }
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
    }
}   