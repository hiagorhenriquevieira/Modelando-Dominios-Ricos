using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities
{
    public class Assinatura
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public bool Ativa { get; set; }
        public List<Pagamento> Pagamentos { get; set; }
    }
}