using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelando.Shareds.ValueObjects;

namespace Modelando.Domain.ValueObjects
{
    public class Nome : ValueObject

    {
        public Nome(string primeiroNome, string sobreNome)
        {
            PrimeiroNome = primeiroNome;
            SobreNome = sobreNome;

            if (string.IsNullOrEmpty(PrimeiroNome))
            {
                AddNotification("Nome.PrimeiroNome", "Nome inálido");
            }
        }

        public string PrimeiroNome { get; private set; }
        public string SobreNome { get; private set; }
    }
}
