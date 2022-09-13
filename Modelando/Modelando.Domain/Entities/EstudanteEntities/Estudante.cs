using Modelando.Domain.Entities.AssinaturaEntities;
using Modelando.Domain.ValueObjects;
using Modelando.Shareds.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Entities.EstudanteEntities
{
    public class Estudante : Entidade
    {
        private IList<Assinatura> _assinaturas;
        public Estudante(Nome nome, Documento documento, Email email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            _assinaturas = new List<Assinatura>();
        }

        public Nome Nome { get; private set; }
        public Documento Documento{ get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }
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
