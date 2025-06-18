using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Domain.Shared
{
    public class Notifiable
    {
        public Notification Notification { get; internal set; } = new();
    }
}
