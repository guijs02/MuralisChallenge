using Muralis.Domain.Aggregates;
using Muralis.Domain.Factory;
using Muralis.Domain.Validators;
using Muralis.Domain.ValueObject;

namespace Muralis.Domain.Entitiy
{
    public class Cliente : Entity
    {
        public Cliente(Guid id, string nome, Endereco endereco, List<Contato> contatos) : base(id)
        {
            Nome = nome;
            DataCadastro = DateTime.Now;
            Endereco = endereco;
            Contatos = contatos;
            Validar();
        }
        
        public string Nome { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Endereco Endereco { get; private set; }
        public List<Contato> Contatos { get; private set; }

        public void Validar()
        {
            ValidationFactory.Validate(this, new ClienteValidator());
        }
    }
}
