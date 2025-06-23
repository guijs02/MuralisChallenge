using System.Text.RegularExpressions;

namespace Muralis.Domain.Validators
{
    public class CepValidator
    {
        private static readonly Regex CepRegex = new Regex(@"^\d{5}-?\d{3}$");

        public static string? ObterCepNormalizado(string cep)
        {
            if (!Validar(cep))
            {
                return null;
            }

            var cepNormalizado = cep.Replace("-", "").Trim();

            return cepNormalizado;
        }
        private static bool Validar(string cep)
        {
            return CepRegex.IsMatch(cep);
        }
    }
}
