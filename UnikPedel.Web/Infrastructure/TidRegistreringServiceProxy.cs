using System.Net.Mime;
using System.Text;
using System.Text.Json;
using UnikPedel.Contract.IServiceTidRegistrering;
using UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos;

namespace UnikPedel.Web.Infrastructure
{
    public class TidRegistreringServiceProxy :IServiceTidRegistrering
    {
        private readonly HttpClient _client;
        public TidRegistreringServiceProxy(HttpClient client)
        {
            _client = client;
        }
        public async Task CreateTidRegistreringAsync(TidRegistreringCreateDto tidRegistrering)
        {
            var registreringDtoJson = new StringContent(
               JsonSerializer.Serialize(tidRegistrering),
               Encoding.UTF8,
               MediaTypeNames.Application.Json);
            await _client.PostAsync("/api/TidRegistrering", registreringDtoJson);
        }

        public async Task DeleteTidRegistreringAsync(int id)
        {
            await _client.DeleteAsync($"/api/TidRegistrering/{id}");
        }

        public async Task EditTidRegistreringAsync(TidRegistreringCreateDto tidRegistrering)
        {
            var registreringDtoJson = new StringContent(
               JsonSerializer.Serialize(tidRegistrering),
               Encoding.UTF8,
               MediaTypeNames.Application.Json);
            await _client.PutAsync("/api/TidRegistrering", registreringDtoJson);
        }

        public async Task<TidRegistreringDto?> GetTidRegistreringAsync(int Id)
        {
            return await _client.GetFromJsonAsync<TidRegistreringDto?>($"/api/TidRegistrering/{Id}");
        }

        public async Task<IEnumerable<TidRegistreringDto>> GetTidRegistreringAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<TidRegistreringDto>>($"api/TidRegistrering");
        }
    }
}
