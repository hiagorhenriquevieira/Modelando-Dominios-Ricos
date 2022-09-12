using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities
{
    public class Pagamento
    {
        public string Numero { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataExpiracao { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPago { get; set; }
        public string Documento { get; set; }
        public string  Proprietario { get; set; }
        public string Endereco { get; set; }
    }

    public class BoletoPagamento : Pagamento
    {
        public string CodigoBarra { get; set; }
        public string Email { get; set; }
        public string NumeroBoleto { get; set; }

    }
    
    public class CartaoDeCreditoPagamento : Pagamento
    {
        public string NomeDonoCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string NumeroDaUltimaTransacao { get; set; }
    }
    
    public class PayPalPagamento : Pagamento
    {
        public string Email { get; set; }
        public string CodigoTransacao { get; set; }
    }
}