using Modelando.Domain.Entities.EstudanteEntities;
using System;
using System.Linq.Expressions;

namespace Modelando.Domain.Queries
{
    public static class EstudanteQueries
    {
        public static Expression<Func<Estudante, bool>> AtribuirInformacoesEstudante(string documento)
        {
            return x => x.Documento.Numero == documento; 
        }
    }
}