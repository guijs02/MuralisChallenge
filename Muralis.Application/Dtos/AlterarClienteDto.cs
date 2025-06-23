using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Application.Dtos
{
    public class AlterarClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
    }
}
