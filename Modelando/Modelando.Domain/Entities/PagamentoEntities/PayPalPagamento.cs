using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities.PagamentoEntities
{
    public class PayPalPagamento : Pagamento
    {
        public string Email { get; set; }
        public string CodigoTransacao { get; set; }
    }
}
