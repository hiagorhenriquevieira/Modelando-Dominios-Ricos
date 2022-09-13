using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelando.Shareds.ValueObjects;

namespace Modelando.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string nomeEmail)
        {
            NomeEmail = nomeEmail;
        }

        public string NomeEmail { get; private set; }
    }
}
