using Muralis.Domain.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Domain.Aggregates
{
    public class Contato : Entity
    {
        public Contato(Guid id, string tipo, string texto, Guid clienteId) : base(id)
        {
            Tipo = tipo;
            Texto = texto;
            ClienteId = clienteId;
        }

        public string Tipo { get; private set; }
        public string Texto { get; private set; }
        public Guid ClienteId { get; private set; }

    }
}
