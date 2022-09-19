using Flunt.Notifications;
using Flunt.Validations;
using Modelando.Shareds.ValueObjects;

namespace Modelando.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string rua, string numero, string bairro, string cidade, string estado, string pais, string codigoPostal)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            CodigoPostal = codigoPostal;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerOrEqualsThan(Rua.Length, 10, "PrimeiroNome.Nome", "Nome deve conter no minimo 3 caracteres")
            );
        }

        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public string CodigoPostal { get; private set; }
    }
}