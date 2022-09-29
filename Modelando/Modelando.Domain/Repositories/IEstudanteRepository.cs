using Modelando.Domain.Entities.EstudanteEntities;
using Modelando.Domain.ValueObjects;

namespace Modelando.Domain.Repositories
{
    public interface IEstudanteRepository
    {
        bool ExisteDocumento(string document);
        bool ExisteEmail(string email);

        void CriarAssinatura(Estudante estudante);
    }
}
