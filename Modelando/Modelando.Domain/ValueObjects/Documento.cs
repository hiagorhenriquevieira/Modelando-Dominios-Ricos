using Modelando.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelando.Shareds.ValueObjects;

namespace Modelando.Domain.ValueObjects
{
    public class Documento : ValueObject
    {
        public Documento(string numero, ETipoDocumento tipoDocumento)
        {
            Numero = numero;
            TipoDocumento = tipoDocumento;
        }

        public string Numero { get; private set; }
        public ETipoDocumento TipoDocumento { get; private set; }
    }
}
