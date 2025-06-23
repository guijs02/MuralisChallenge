using System.ComponentModel.DataAnnotations;

namespace Muralis.Application.Dtos
{
    public class ContatoDto
    {
        public string Tipo { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
    }
}
