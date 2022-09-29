using Flunt.Notifications;
using Flunt.Validations;
using Modelando.Shareds.ValueObjects;

namespace Modelando.Domain.ValueObjects
{
    public class Nome : ValueObject

    {
        public Nome(string primeiroNome, string sobreNome)
        {
            PrimeiroNome = primeiroNome;
            SobreNome = sobreNome;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerThan(PrimeiroNome,3,"PrimeiroNome.Nome", "Nome deve conter no minimo 3 caracteres")
                .IsLowerThan(SobreNome,3, "SobreNome.Nome", "Sobrenome deve conter no minimo 3 caracteres")
                .IsGreaterThan(PrimeiroNome,40, "PrimeiroNome.Nome", "Nome deve conter no máximo 40 caracteres")
            );
        }

        public string PrimeiroNome { get; private set; }
        public string SobreNome { get; private set; }


        public override string ToString()
        {
            return $"{PrimeiroNome} {SobreNome}";
        }
    }
}