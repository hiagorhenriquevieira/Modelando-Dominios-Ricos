using Modelando.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities.PagamentoEntities
{
    public class PayPalPagamento : Pagamento
    {
        public PayPalPagamento(
            Email email, 
            string codigoTransacao, 
            DateTime dataPagamento, 
            DateTime dataExpiracao, 
            decimal total, 
            decimal totalPago,
            Documento documento, 
            string proprietario,
            Endereco endereco) : base(
                dataPagamento,
                dataExpiracao,
                total,
                totalPago,
                documento,
                proprietario,
                endereco)
        {
            Email = email;
            CodigoTransacao = codigoTransacao;
        }

        public Email Email { get; private set; }
        public string CodigoTransacao { get; private set; }
    }
}
