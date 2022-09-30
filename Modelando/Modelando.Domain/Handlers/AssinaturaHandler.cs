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

        private Nome _nome;
        private Endereco _endereco;
        private Documento _documento;
        private Email _email;
        private Estudante _estudante;
        private Assinatura _assinatura;
        private BoletoPagamento _boletoPagamento;

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
                return AdicionarNotificacao("Documento", "Esse documento já existe", false, "Não foi possivel realizar assinatura");


            //Verificar se E-mail já está cadastrado
            if (_repository.ExisteEmail(command.EmailPagador))
                return AdicionarNotificacao("EmailPagador", "Esse email já existe", false, "Não foi possivel realizar sua assinatura");

            AdicionarValueObjects(command);

            AdicionarRelacionamento();

            AddNotifications(_nome, _documento, _email, _endereco, _estudante, _assinatura, _boletoPagamento);

            SalvarInformacoes();

            EnviarEmail();

            //Retornar informações

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        private void EnviarEmail() 
            => _emailService.EnviarEmail(_estudante.Nome.ToString(), _estudante.Email.NomeEmail, "Bem vindo ao Batla.io", "Sua assinatura foi criada.");

        private void SalvarInformacoes() 
            => _repository.CriarAssinatura(_estudante);

        private void AdicionarRelacionamento()
        {
            _assinatura.AdicionarPagamento(_boletoPagamento);
            _estudante.AdicionarAssinatura(_assinatura);
        }

        private void AdicionarValueObjects(CriacaoAssinaturaBoletoCommand command)
        {
            _nome = new Nome(command.PrimeiroNome, command.SobreNome);
            _documento = new Documento(command.Documento, Enum.ETipoDocumento.CPF);
            _email = new Email(command.EmailPagador);
            _endereco = new Endereco(command.Rua, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Pais, command.CodigoPostal);
            _estudante = new Estudante(_nome, _documento, _email);
            _assinatura = new Assinatura(System.DateTime.Now.AddMonths(1));
            _boletoPagamento = new BoletoPagamento(command.CodigoBarra, _email, command.NumeroBoleto, command.DataPagamento, command.DataExpiracao, command.Total, command.TotalPago, _documento, command.Proprietario, _endereco);
        }

        private ICommandResult AdicionarNotificacao(string propriedade, string mensagemNotificacao, bool sucesso,string mensagemDeFinalizacao)
        {
            AddNotification(propriedade, mensagemNotificacao);
            return new CommandResult(sucesso, mensagemDeFinalizacao);
        }
    }
}