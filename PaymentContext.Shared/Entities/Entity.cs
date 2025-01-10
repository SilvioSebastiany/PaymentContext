using Flunt.Notifications;

namespace PaymentContext.Shared.Entities
{
    //Classe base para entidades
    public abstract class Entity : Notifiable<Notification>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }

  
}