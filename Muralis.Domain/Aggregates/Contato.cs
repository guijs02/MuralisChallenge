using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Domain.Aggregates
{
    public class Contato
    {
        public Contato(string tipo, string texto)
        {
            Tipo = tipo;
            Texto = texto;
        }
        public string Tipo { get; private set; }
        public string Texto { get; private set; }
       
    }
}
