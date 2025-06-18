namespace Muralis.Domain.ValueObject
{
    public record class Endereco
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
        }

    }
}
