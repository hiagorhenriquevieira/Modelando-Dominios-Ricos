using Flunt.Notifications;
using Flunt.Validations;
using Modelando.Domain.Entities.AssinaturaEntities;
using Modelando.Domain.ValueObjects;
using Modelando.Shareds.Entities;
using System.Collections.Generic;
using System.Linq;

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

            AddNotifications(nome, documento, email);
        }

        public Nome Nome { get; private set; }
        public Documento Documento{ get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas { get { return _assinaturas.ToArray(); } }
    
    public void AdicionarAssinatura(Assinatura assinatura)
        {
            var assinaturaAtiva = ValidarSeExisteAssinaturaAtiva();

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsFalse(assinaturaAtiva, "Estudante.Assinaturas", "Você já tem uma assinatura ativa.")
                .IsLowerOrEqualsThan(0, assinatura.Pagamentos.Count, "Estudante.Asinatura.Pgamentos", "Esta assinatura não possui pagamentos")
                );

            if (assinaturaAtiva == false)
                _assinaturas.Add(assinatura);
        }

        public bool ValidarSeExisteAssinaturaAtiva()
        {
            foreach (var sub in _assinaturas)
            {
                if (sub.Ativa)
                    return true;
            }
            return false;
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