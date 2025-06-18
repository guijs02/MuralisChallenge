namespace Muralis.Domain.ValueObject
{
    public class Endereco : Shared.ValueObject
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public Endereco(string logradouro, 
                        string numero, 
                        string complemento, 
                        string cidade, 
                        string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Cep = cep;

            Validar();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Endereco endereco) return false;

            return Logradouro == endereco.Logradouro &&
                   Numero == endereco.Numero &&
                   Complemento == endereco.Complemento &&
                   Cidade == endereco.Cidade &&
                   Cep == endereco.Cep;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Logradouro))
               Notification.AddErro(nameof(Endereco), "Logradouro não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(Numero))
               Notification.AddErro(nameof(Endereco), "Numero não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(Cidade))
                Notification.AddErro(nameof(Endereco), "Cidade não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(Cep))
                Notification.AddErro(nameof(Endereco), "Cidade não pode ser vazio.");
                
        }
        public static bool operator ==(Endereco left, Endereco right) => left.Equals(right);

        public static bool operator !=(Endereco left, Endereco right) => !left.Equals(right);

        public override int GetHashCode()
        {
            return HashCode.Combine(Logradouro, Numero, Complemento, Cidade, Cep);
        }
    }
}
