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
        public Nome(int primeiroNome, int sobreNome)
        {
            PrimeiroNome = primeiroNome;
            SobreNome = sobreNome;
        }

        public int PrimeiroNome { get; private set; }
        public int SobreNome { get; private set; }
    }
}
