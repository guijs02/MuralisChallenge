using Muralis.Domain.Entitiy;
using Muralis.Domain.ValueObject;
using Muralis.Domain.Aggregates;

namespace Muralis.Domain.Factory
{
    public static class ClienteFactory
    {
        public static Cliente Criar(ClienteProps cliente)
        {
            var endereco = new Endereco(
            logradouro: cliente.Logradouro, // Ajuste conforme necessário
            numero: cliente.Numero,
            complemento: cliente.Complemento, // Ajuste conforme necessário
            cidade: cliente.Cidade, // Ajuste conforme necessário
            cep: cliente.Cep
          );

            Guid clienteId = Guid.NewGuid(); // Gerar um novo ID para o cliente

            List<Contato> Contatos = [];

            cliente.Contatos.ForEach(c =>
            {
                Contatos.Add(new (
                    id: Guid.NewGuid(), // Gerar um novo ID para cada contato
                    tipo: c.Tipo,
                    texto: c.Texto,
                    clienteId: clienteId
                ));
            });

            var clienteDomain = new Cliente(
                id: clienteId,
                nome: cliente.Nome,
                endereco: endereco,
                contatos: Contatos
            );

            return clienteDomain;
        }


    }

    public class ClienteProps
    {
        public string Nome { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public List<ContatoProps> Contatos { get; set; } = new List<ContatoProps>();
        public string Cidade { get; set; }
    }
    public class ContatoProps
    {
        public string Tipo { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
    }
}
