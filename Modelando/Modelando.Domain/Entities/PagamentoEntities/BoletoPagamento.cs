using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities.PagamentoEntities
{
    class BoletoPagamento : Pagamento
    {
        public BoletoPagamento(
            string codigoBarra, 
            string email, 
            string numeroBoleto, 
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
            CodigoBarra = codigoBarra;
            Email = email;
            NumeroBoleto = numeroBoleto;
        }

        public string CodigoBarra { get; private set; }
        public string Email { get; private set; }
        public string NumeroBoleto { get; private set; }
    }
}
