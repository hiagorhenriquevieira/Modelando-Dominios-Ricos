using Flunt.Notifications;
using Flunt.Validations;
using Modelando.Shareds.ValueObjects;

namespace Modelando.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string nomeEmail)
        {
            NomeEmail = nomeEmail;
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsEmail(nomeEmail, "Email.NomeEmail", "E-mail inválido."));
        }

        public string NomeEmail { get; private set; }
    }
}
