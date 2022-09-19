using Flunt.Notifications;
using Flunt.Validations;
using Modelando.Domain.ValueObjects;
using Modelando.Shareds.Entities;
using System;

namespace Modelando.Domain.Entities.PagamentoEntities
{
    public abstract class Pagamento: Entidade
    {
        public Pagamento(DateTime dataPagamento, DateTime dataExpiracao, decimal total, decimal totalPago, Documento documento, string proprietario, Endereco endereco)
        {
            Numero = Guid.NewGuid().ToString().Replace("-", "").Substring(0,10).ToUpper();
            DataPagamento = dataPagamento;
            DataExpiracao = dataExpiracao;
            Total = total;
            TotalPago = totalPago;
            Documento = documento;
            Proprietario = proprietario;
            Endereco = endereco;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerOrEqualsThan(0, Total, "Pagamento.Total", "O total não pode ser zero")
                .IsGreaterOrEqualsThan(Total, TotalPago, "Pagamento.TotalPago", "O valor pago é menor que o valor do pagamento")
                );
        }

        public string Numero { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DateTime DataExpiracao { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPago { get; private set; }
        public Documento Documento { get; private set; }
        public string Proprietario { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}