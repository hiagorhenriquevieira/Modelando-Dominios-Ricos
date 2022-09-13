using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities.PagamentoEntities
{
    class CartaoDeCreditoPagamento : Pagamento
    {
        public CartaoDeCreditoPagamento(
            string nomeDonoCartao, 
            string numeroCartao, 
            string numeroDaUltimaTransacao, 
            DateTime dataPagamento, 
            DateTime dataExpiracao, 
            decimal total, 
            decimal totalPago, 
            string documento, 
            string proprietario, 
            string endereco) : base(
                dataPagamento,
                dataExpiracao,
                total,
                totalPago,
                documento,
                proprietario,
                endereco)
        {
            NomeDonoCartao = nomeDonoCartao;
            NumeroCartao = numeroCartao;
            NumeroDaUltimaTransacao = numeroDaUltimaTransacao;
        }

        public string NomeDonoCartao { get; private set; }
        public string NumeroCartao { get; private set; }
        public string NumeroDaUltimaTransacao { get; private set; }
    }
}
