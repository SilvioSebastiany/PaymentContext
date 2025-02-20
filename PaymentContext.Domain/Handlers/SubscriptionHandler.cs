using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers{
    public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>
    {
        //Injeção de dependência do repositório de estudantes e do serviço de e-mail
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;

        //Construtor para injeção de dependência
        public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
        {
            _studentRepository = studentRepository;
            _emailService = emailService;
        }
        
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            //Verificar se o documento já está cadastrado
            if (_studentRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se o email já está cadastrado
            if (_studentRepository.EmailExists(command.Email))
                AddNotification("Email", "Este email já está em uso");
                
            //Gerar os VOs (Value Objects)
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDucumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            //Gerar as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address, email);
            
            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Agrupar as validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            //Checar as notificações
            if (!IsValid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            //Salvar as informações
            _studentRepository.CreateSubscription(student);
            
            //Enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao balta.io", "Sua assinatura foi criada");
            
            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}