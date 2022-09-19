using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelando.Domain.ValueObjects;

namespace Modelando.Tests.ValueObjects
{
    [TestClass]
    public class DocumentoTest
    {
        [TestMethod]
        public void Deve_retornar_um_erro_quando_CNPJ_for_invalido()
        {
            var doc = new Documento("123", Domain.Enum.ETipoDocumento.CNPJ);
            Assert.IsFalse(doc.Validar());
        }

        [TestMethod]
        public void Deve_retornar_sucesso_quando_CNPJ_for_invalido()
        {
            var doc = new Documento("12345678910111", Domain.Enum.ETipoDocumento.CNPJ);
            Assert.IsTrue(doc.Validar());
        }

        [TestMethod]
        public void Deve_retornar_um_erro_quando_CPF_for_invalido()
        {
            var doc = new Documento("123", Domain.Enum.ETipoDocumento.CPF);
            Assert.IsFalse(doc.Validar());
        }

        [TestMethod]
        public void Deve_retornar_sucesso_quando_CPF_for_invalido()
        {
            var doc = new Documento("12345678910", Domain.Enum.ETipoDocumento.CPF);
            Assert.IsTrue(doc.Validar());
        }
    }
}