using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(
            string lastTransactionCode, 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal totalPaid, 
            string owner, 
            Document document, 
            Address address, 
            Email email) : base( paidDate,  expireDate,  total,  totalPaid,  owner,  document,  address,  email)
        {
            LastTransactionCode = lastTransactionCode;
        }

        public string LastTransactionCode { get; private set; }
    }
}