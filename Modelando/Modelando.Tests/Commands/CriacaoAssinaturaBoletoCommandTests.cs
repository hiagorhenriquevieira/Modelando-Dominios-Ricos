using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelando.Domain.Commands;

namespace Modelando.Tests.Commands
{
    [TestClass]
    public class CriacaoAssinaturaBoletoCommandTests
    {
        [TestMethod]
        public void Deve_retornar_verdadeiro_quando_nome_tem_mais_de_dois_caracteres()
        {
            var command = new CriacaoAssinaturaBoletoCommand();

            command.PrimeiroNome = "Hia";

            command.validate();

            var sut = command.IsValid;

            Assert.IsTrue(sut);
        }
        
        [TestMethod]
        public void Deve_retornar_falso_quando_nome_tem_mais_de_40_caracteres()
        {
            var command = new CriacaoAssinaturaBoletoCommand();

            command.PrimeiroNome = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa ";

            command.validate();

            var sut = command.IsValid;

            Assert.IsFalse(sut);
        }

        [TestMethod]
        public void Deve_retornar_falso_quando_sobreNome_tem_mais_de_40_caracteres()
        {
            var command = new CriacaoAssinaturaBoletoCommand();

            command.SobreNome = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            command.validate();

            var sut = command.IsValid;

            Assert.IsFalse(sut);
        }

    }
}
