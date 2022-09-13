using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities.PagamentoEntities
{
    class BoletoPagamento : Pagamento
    {
        public string CodigoBarra { get; set; }
        public string Email { get; set; }
        public string NumeroBoleto { get; set; }
    }
}
