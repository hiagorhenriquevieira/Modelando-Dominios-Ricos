using Modelando.Domain.Entities.EstudanteEntities;
using Modelando.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelando.Domain.Repositories
{
   public interface IEstudanteRepository
    {
        Documento ObterDocumentoExistente(string document);
        Email ObterEmailExistente(string email);

        void CriarAssinatura(Estudante estudante);
    }
}
