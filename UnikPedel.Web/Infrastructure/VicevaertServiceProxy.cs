using System.Net.Mime;
using System.Text;
using System.Text.Json;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Contract.IServiceVicevaert;
using UnikPedel.Contract.VicevaertDtos;

namespace UnikPedel.Web.Infrastructure
{
    public class VicevaertServiceProxy : IVicevaertService
    {
        private readonly HttpClient _client;

        public VicevaertServiceProxy(HttpClient client)
        {
            _client = client;
        }

        async Task IVicevaertService.CreateVicevaertAsync(VicevaertCreateDto vicevaert)
        {
            var vicevaertDtoJson = new StringContent(
                JsonSerializer.Serialize(vicevaert),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PostAsync("/api/Vicevaert", vicevaertDtoJson);
        }

        async Task IVicevaertService.DeleteVicevaertAsync(int Id)
        {
            await _client.DeleteAsync($"/api/Vicevaert/{Id}");
        }

        async Task IVicevaertService.EditVicevaertAsync(VicevaertDto vicevaert)
        {
            var vicevaertDtoJson = new StringContent(
                JsonSerializer.Serialize(vicevaert),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PutAsync("/api/Viceveart", vicevaertDtoJson);
        }

        async Task<VicevaertDto?> IVicevaertService.GetVicevaertAsync(int Id)
        {
            return await _client.GetFromJsonAsync<VicevaertDto?>($"/api/Vicevaert/{Id}");
        }

        async Task<IEnumerable<VicevaertDto>> IVicevaertService.GetVicevaerterAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<VicevaertDto>>($"api/Vicevaert");
        }
    }
}
