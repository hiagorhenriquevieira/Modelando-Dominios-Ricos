using Modelando.Domain.Entities.EstudanteEntities;
using Modelando.Domain.Repositories;

namespace Modelando.Tests.Mocks
{
    public class EstudanteRepositoryFake : IEstudanteRepository
    {
        public void CriarAssinatura(Estudante estudante)
        {

        }

        public bool ExisteDocumento(string documento)
        {
            if (documento == "99999999999")
                return true;

            return false;
        }

        public bool ExisteEmail(string email)
        {
            if (email  == "hello@balta.io")
                return true;

            return false;
        }
    }
}
