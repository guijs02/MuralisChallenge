using Muralis.Domain.Response;
using System.Net;
using System.Text.Json;

namespace Muralis.Application.Services
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;
        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Resposta<CepResult>?> BuscarPorCepAsync(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new Resposta<CepResult>(null, codigo: (int)response.StatusCode);

            var json = await response.Content.ReadAsStringAsync();

            var viaCep = JsonSerializer.Deserialize<ViaCepResponse>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (viaCep is null)
                return new Resposta<CepResult>(null, codigo: (int)HttpStatusCode.InternalServerError);

            var cepResult = new CepResult(
                Cep: viaCep.Cep ?? string.Empty,
                Logradouro: viaCep.Logradouro ?? string.Empty,
                Cidade: viaCep.Localidade ?? string.Empty,
                Estado: viaCep.Uf ?? string.Empty,
                Complemento: viaCep.Complemento ?? string.Empty
            );

            return new Resposta<CepResult>(cepResult);
        }
    }
}
