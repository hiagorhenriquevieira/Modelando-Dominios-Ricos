using Flunt.Notifications;
using Modelando.Domain.Commands;
using Modelando.Domain.Entities.AssinaturaEntities;
using Modelando.Domain.Entities.EstudanteEntities;
using Modelando.Domain.Entities.PagamentoEntities;
using Modelando.Domain.Repositories;
using Modelando.Domain.Services;
using Modelando.Domain.ValueObjects;
using Modelando.Shareds.Commands;
using Modelando.Shareds.Handlers;

namespace Modelando.Domain.Handlers
{
    public class AssinaturaHandler : Notifiable<Notification>, IHandler<CriacaoAssinaturaBoletoCommand>
    {
        private readonly IEstudanteRepository _repository;
        private readonly IEmailService _emailService;

        public AssinaturaHandler(IEstudanteRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CriacaoAssinaturaBoletoCommand command)
        {
            //Fail fast validations
            command.validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }
            //Verificar se documento já está cadastrado
            if (_repository.ExisteDocumento(command.Documento))
            {
                AddNotification("Documento", "Esse documento já existe");
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }
            //Verificar se E-mail já está cadastrado
            if (_repository.ExisteEmail(command.EmailPagador))
            {
                AddNotification("EmailPagador", "Esse email já existe");
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }
            //Gerar os VOs
            var nome = new Nome(command.PrimeiroNome, command.SobreNome);
            var documento = new Documento(command.Documento, Enum.ETipoDocumento.CPF);
            var email = new Email(command.EmailPagador);
            var endereco = new Endereco(command.Rua, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Pais, command.CodigoPostal);

            //Gerar as Entidades
            var estudante = new Estudante(nome, documento, email);
            var assinatura = new Assinatura(System.DateTime.Now.AddMonths(1));
            var pagamento = new BoletoPagamento(command.CodigoBarra, email, command.NumeroBoleto, command.DataPagamento, command.DataExpiracao, command.Total, command.TotalPago, documento, command.Proprietario, endereco);

            //relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            estudante.AdicionarAssinatura(assinatura);

            //Agrupar as validações
            AddNotifications(nome, documento, email, endereco, estudante, assinatura, pagamento);

            //Salvar as informações
            _repository.CriarAssinatura(estudante);

            //Enviar e-mail de boas vindas
            _emailService.EnviarEmail(estudante.Nome.ToString(), estudante.Email.NomeEmail, "Bem vindo ao Batla.io", "Sua assinatura foi criada.");
            
            //Retornar informações

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}
