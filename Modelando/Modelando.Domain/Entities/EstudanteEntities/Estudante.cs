using Modelando.Domain.Entities.AssinaturaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities.EstudanteEntities
{
    public class Estudante
    {
        private IList<Assinatura> _assinaturas;
        public Estudante(string primeiroNome, string sobreNome, string documento, string email)
        {
            PrimeiroNome = primeiroNome;
            SobreNome = sobreNome;
            Documento = documento;
            Email = email;
            _assinaturas = new List<Assinatura>();
        }

        public string PrimeiroNome { get; private set; }
        public string SobreNome { get; private set; }
        public string Documento{ get; private set; }
        public string Email{ get; private set; }
        public string Endereco { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas { get { return _assinaturas.ToArray(); } }
    
    
    public void AdicionarAssinatura(Assinatura assinatura)
        {
            DesativarTodasAssinaturas();

            _assinaturas.Add(assinatura);
        }

        private void DesativarTodasAssinaturas()
        {
            foreach (var assinatura in Assinaturas)
            {
                assinatura.DesativarAssinatura();
            }
        }
    }
}
