using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelando.Domain.Entities.AssinaturaEntities;
using Modelando.Domain.Entities.EstudanteEntities;
using Modelando.Domain.Entities.PagamentoEntities;
using Modelando.Domain.ValueObjects;
using System;

namespace Modelando.Tests.Entities
{
    [TestClass]
    public class EstudanteTests
    {
        private readonly Estudante _estudante;
        private readonly Nome _nome;
        private readonly Assinatura _assinatura;
        private readonly Endereco _endereco;
        private readonly Documento _documento;
        private readonly Email _email;

        public EstudanteTests()
        {
            _nome = new Nome("Hiágor", "Vieira");
            _documento = new Documento("12345678910", Domain.Enum.ETipoDocumento.CPF);
            _email = new Email("hiagor@estudo.com");
            _estudante = new Estudante(_nome, _documento, _email);
            _endereco = new Endereco("Rua 1", "1234", "Centro", "São Francisco", "SP", "BR", "134000000");
            _assinatura = new Assinatura(null);

        }


        [TestMethod]
        public void Deve_retornar_um_erro_quando_estudante_ja_tiver_uma_assinatura_ativa()
        {
            var pagamento = new PayPalPagamento(_email, "12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _documento, _nome.ToString(), _endereco);

            _assinatura.AdicionarPagamento(pagamento);
            _estudante.AdicionarAssinatura(_assinatura);
            _estudante.AdicionarAssinatura(_assinatura);

            Assert.IsTrue(_estudante.ValidarSeExisteAssinaturaAtiva());

        }
        //public void Deve_retornar_sucesso_quando_estudante_nao_tiver_uma_assinatura_ativa()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod]
        //public void Deve_retornar_um_erro_quando_assinatura_nao_tiver_pagamento()
        //{

        //    _estudante.AdicionarAssinatura(_assinatura);
        //    Assert.IsFalse(_estudante.IsValid);
        //    Assert.Fail();

        //}
    }
}