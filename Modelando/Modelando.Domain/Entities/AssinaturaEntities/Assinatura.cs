using Flunt.Notifications;
using Flunt.Validations;
using Modelando.Domain.Entities.PagamentoEntities;
using Modelando.Shareds.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelando.Domain.Entities.AssinaturaEntities
{
    public class Assinatura : Entidade
    {
        private IList<Pagamento> _pagamento;

        public Assinatura(DateTime? dataExpiracao)
        {
            DataCriacao = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            DataExpiracao = dataExpiracao;
            Ativa = true;
            _pagamento = new List<Pagamento>();
        }

        public DateTime DataCriacao { get; private set; }
        public DateTime DataUltimaAtualizacao { get; private set; }
        public DateTime? DataExpiracao { get; private set; }
        public bool Ativa { get; private set; }
        public IReadOnlyCollection<Pagamento> Pagamentos { get { return _pagamento.ToArray(); } }
    
        public void DesativarAssinatura()
        {
            Ativa = false;
            DataUltimaAtualizacao = DateTime.Now;
        }
        public void AtivarAssinatura()
        {
            Ativa = true;
            DataUltimaAtualizacao = DateTime.Now;
        }

        public void AdicionarPagamento(Pagamento pagamento)
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(DateTime.Now, pagamento.DataPagamento, "Assinatura.Pagamentos", "A data do pagamento deve ser futura.")
                );
            _pagamento.Add(pagamento);
        }
    }
}