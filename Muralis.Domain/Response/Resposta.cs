using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Muralis.Domain.Response
{
    public class Resposta<T>(T? dado,
     string? mensagem = null,
     int codigo = 200)
    {
        public T? Dados { get; set; } = dado;
        public int CodigoStatus => codigo;
        public string? Mensagem { get; set; } = mensagem;
        [JsonIgnore]
        public bool Sucesso => codigo is >= 200 and <= 299;
    }
}
