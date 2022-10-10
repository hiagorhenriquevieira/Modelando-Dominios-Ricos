using Flunt.Notifications;
using Flunt.Validations;
using Modelando.Domain.Enum;
using Modelando.Domain.ValueObjects;
using Modelando.Shareds.Commands;
using System;

namespace Modelando.Domain.Commands
{
    public class CriacaoAssinaturaBoletoCommand : Notifiable<Notification>, ICommand
    {
        public string PrimeiroNome { get; set; }
        public string SobreNome { get; set; }
        public string Documento { get; set; }
        public string NomeEmail { get; set; }
        public string CodigoBarra { get; set; }
        public string NumeroBoleto { get; set; }
        public string PagamentoNumero { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataExpiracao { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPago { get; set; }
        public string DocumentoPagador { get; set; }
        public ETipoDocumento TipoDocumentoPagador { get; set; }
        public string EmailPagador { get; set; }
        public string Proprietario { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CodigoPostal { get; set; }

        public void validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerOrEqualsThan(SobreNome, 40, "SobreNome.Nome", "Sobrenome deve conter no máximo 40 caracteres")
                .IsGreaterOrEqualsThan(PrimeiroNome, 3, "PrimeiroNome.Nome", "Nome deve conter no minímo 3 caracteres")
                .IsLowerOrEqualsThan(PrimeiroNome, 40, "PrimeiroNome.Nome", "Nome deve conter no minímo 40 caracteres")
                );
        }
    }
}