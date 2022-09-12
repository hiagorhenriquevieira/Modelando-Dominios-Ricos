using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities
{
    public class Estudante
    {
        public string PrimeiroNome { get; set; }
        public string SobreNome { get; set; }
        public string Documento{ get; set; }
        public string Email{ get; set; }
        public List<Assinatura> Assinaturas { get; set; }
        public string Endereco { get; set; }
    }
}
