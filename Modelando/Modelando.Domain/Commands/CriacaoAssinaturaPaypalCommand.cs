using Modelando.Domain.Enum;
using Modelando.Domain.ValueObjects;
using System;

namespace Modelando.Domain.Commands
{
    public class CriacaoAssinaturaPaypalCommand
    {
        public string PrimeiroNome { get; set; }
        public string SobreNome { get; set; }
        public string Documento { get; set; }
        public string NomeEmail { get; set; }
        public string CodigoTransacao { get; set; }
        public string PagamentoNumero { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataExpiracao { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPago { get; set; }
        public Documento DocumentoPagador { get; set; }
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
    }
}
