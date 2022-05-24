using System.Net.Mime;
using System.Text;
using System.Text.Json;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Contract.IServiceVicevært;
using UnikPedel.Contract.ViceværtDtos;

namespace UnikPedel.Web.Infrastructure
{
    public class ViceværtServiceProxy : IViceværtService
    {
        private readonly HttpClient _client;

        public ViceværtServiceProxy(HttpClient client)
        {
            _client = client;
        }

        async Task IViceværtService.CreateViceværtAsync(ViceværtCreateDto vicevært)
        {
            var viceværtDtoJson = new StringContent(
                JsonSerializer.Serialize(vicevært),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PostAsync("/api/Vicevært", viceværtDtoJson);
        }

        async Task IViceværtService.DeleteViceværtAsync(int Id)
        {
            await _client.DeleteAsync($"/api/Vicevært/{Id}");
        }

        async Task IViceværtService.EditViceværtAsync(ViceværtDto vicevært)
        {
            var viceværtDtoJson = new StringContent(
                JsonSerializer.Serialize(vicevært),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PutAsync("/api/Vicevært", viceværtDtoJson);
        }

        async Task<ViceværtDto?> IViceværtService.GetViceværtAsync(int Id)
        {
            return await _client.GetFromJsonAsync<ViceværtDto?>($"/api/Vicevært/{Id}");
        }

        async Task<IEnumerable<ViceværtDto>> IViceværtService.GetViceværterAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<ViceværtDto>>($"api/Vicevært");
        }
    }
}
