using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities.PagamentoEntities
{
    class CartaoDeCreditoPagamento : Pagamento
    {
        public string NomeDonoCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string NumeroDaUltimaTransacao { get; set; }
    }
}
