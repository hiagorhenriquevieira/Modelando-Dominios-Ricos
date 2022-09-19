using Flunt.Notifications;
using Flunt.Validations;
using Modelando.Domain.Enum;
using Modelando.Shareds.ValueObjects;

namespace Modelando.Domain.ValueObjects
{
    public class Documento : ValueObject
    {
        public Documento(string numero, ETipoDocumento tipoDocumento)
        {
            Numero = numero;
            TipoDocumento = tipoDocumento;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsTrue(Validar(), "Numero.Documento", "Documento inválido")
                );
        }

        public string Numero { get; private set; }
        public ETipoDocumento TipoDocumento { get; private set; }

        public bool Validar()
        {
            if (TipoDocumento == ETipoDocumento.CNPJ && Numero.Length == 14) return true;

            if (TipoDocumento == ETipoDocumento.CPF && Numero.Length == 11) return true;

            return false;
        }
    }
}