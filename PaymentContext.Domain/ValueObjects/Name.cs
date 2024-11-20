using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firsName, string lastName)
        {
            FirsName = firsName;
            LastName = lastName;

            if(string.IsNullOrEmpty(FirsName))
            {
                AddNotification("Name.FirstName","Nome inválido");
            }

            AddNotifications(new Contract<string>()
                .Requires()
                .IsLowerThan(FirsName, 3, "Name.FirsName","Nome deve conter pelo menos 3 caracteres")
                .IsLowerThan(LastName, 3, "Name.LastName","Sobrenome deve conter pelo menos 3 caracteres")
                .IsGreaterThan(FirsName, 40, "Name.FirsNamee","Nome deve conter até 40 caracteres"));
        }

        public string FirsName { get; private set; }
        public string LastName { get; private set; }
    }
}