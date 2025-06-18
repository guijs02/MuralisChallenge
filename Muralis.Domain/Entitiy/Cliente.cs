using Muralis.Domain.ValueObject;

namespace Muralis.Domain.Entitiy
{
    public class Cliente
    {
        public Cliente(string nome, Endereco endereco)
        {
            Nome = nome;
            DataCadastro = DateTime.Now;
            Endereco = endereco;
        }
        public string Nome { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Endereco Endereco { get; private set; }

        public void Validar()
        {
            if(string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("Nome do cliente não pode ser vazio ou nulo.");

            if (DataCadastro == default)
                throw new ArgumentException("Data de cadastro inválida.");
        }
    }
}
