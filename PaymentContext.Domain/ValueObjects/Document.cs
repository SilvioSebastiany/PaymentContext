using System.ComponentModel.DataAnnotations;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDucumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract<string>()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido"));
        }

        public string Number { get; private set; }
        public EDucumentType Type { get; private set; }

        private bool Validate(){
            if(Type == EDucumentType.CNPJ && Number.Length == 14)
                return true;

            if(Type == EDucumentType.CPF && Number.Length == 11)
                return true;

            return false;
        }
    }
}