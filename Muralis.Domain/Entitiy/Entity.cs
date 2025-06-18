using Muralis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Domain.Entitiy
{
    public class Entity : Notifiable
    {
        public Entity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }

}
