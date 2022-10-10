using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelando.Domain.Entities.EstudanteEntities;
using Modelando.Domain.Queries;
using Modelando.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Modelando.Tests.Queries
{
    [TestClass]
    public class EstudanteQueriesTest
    {
        private IList<Estudante> _estudante = new List<Estudante>();
        
        public EstudanteQueriesTest()
        {
            for (var i = 0; i <= 10; i++)
            {
                _estudante.Add(new Estudante(
                    new Nome("Aluno,", i.ToString()),
                    new Documento("1111111111" + i.ToString(), Domain.Enum.ETipoDocumento.CPF),
                    new Email(i.ToString() + "@balta.io")
                    ));
            }
        }

        [TestMethod]
        public void Deve_retornar_documento_vazio_se_nao_existir_documento()
        {
            var exp = EstudanteQueries.AtribuirInformacoesEstudante("12345678911");
            var estudante = _estudante.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, estudante);
        }

        [TestMethod]
        public void Deve_retornar_documento_preenchido_se_existir_documento()
        {
            var exp = EstudanteQueries.AtribuirInformacoesEstudante("11111111111");
            var estudante = _estudante.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual("11111111111", estudante.Documento.Numero);
        }
    }
}
