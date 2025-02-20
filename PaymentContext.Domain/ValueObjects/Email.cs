
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract<string>()
                .Requires()
                .IsEmail(Address, "Email.Adress","E-mail invalido"));
        }

        public string Address { get; private set; }
    }

}