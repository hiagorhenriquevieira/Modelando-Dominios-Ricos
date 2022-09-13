using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities.PagamentoEntities
{
    public abstract class Pagamento
    {
        public Pagamento(DateTime dataPagamento, DateTime dataExpiracao, decimal total, decimal totalPago, string documento, string proprietario, string endereco)
        {
            Numero = Guid.NewGuid().ToString().Replace("-", "").Substring(0,10).ToUpper();
            DataPagamento = dataPagamento;
            DataExpiracao = dataExpiracao;
            Total = total;
            TotalPago = totalPago;
            Documento = documento;
            Proprietario = proprietario;
            Endereco = endereco;
        }

        public string Numero { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DateTime DataExpiracao { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPago { get; private set; }
        public string Documento { get; private set; }
        public string Proprietario { get; private set; }
        public string Endereco { get; private set; }
    }
}