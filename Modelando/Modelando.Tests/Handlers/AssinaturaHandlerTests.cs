using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelando.Domain.Commands;
using Modelando.Domain.Handlers;
using Modelando.Tests.Mocks;
using System;

namespace Modelando.Tests.Handlers
{
    [TestClass]
    public class AssinaturaHandlerTests
    {
        [TestMethod]
        public void Deve_retornar_erro_se_documento_ja_informado()
        {
            var handler = new AssinaturaHandler(new EstudanteRepositoryFake(), new EmailServiceFake());
            var command = new CriacaoAssinaturaBoletoCommand();

            command.PrimeiroNome = "Hiagor";
            command.SobreNome = "Vieira";
            command.Documento = "121";
            command.NomeEmail = "teste@balta.io";
            command.CodigoBarra = "123456789";
            command.NumeroBoleto = "1234567";
            command.PagamentoNumero = "123123";
            command.DataPagamento = DateTime.Now;
            command.DataExpiracao = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPago = 60;
            command.DocumentoPagador = "12345678910";
            command.TipoDocumentoPagador = Domain.Enum.ETipoDocumento.CPF;
            command.EmailPagador = "hiago@balta.io";
            command.Proprietario = "Hiagor H. Vieira";
            command.Rua = "Rua teste";
            command.Numero = "Numero teste";
            command.Bairro = "Bairro teste";
            command.Cidade = "Cidade teste";
            command.Estado = "Estado teste";
            command.Pais = "Pais teste";
            command.CodigoPostal = "12345678";


            handler.Handle(command);

            Assert.AreEqual(false, handler.IsValid);
        }

    }
}
