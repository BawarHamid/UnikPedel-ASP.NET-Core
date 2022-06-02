using System.Net.Mime;
using System.Text;
using System.Text.Json;
using UnikPedel.Contract.IServiceLejmaal;
using UnikPedel.Contract.IServiceLejmaal.LejemaalDtos;

namespace UnikPedel.Web.Infrastructure
{
    public class LejemaalServiceProxy : IServiceLejemaal
    {
        private readonly HttpClient _client;
        public LejemaalServiceProxy(HttpClient client)
        {
            _client = client;
        }

        async Task IServiceLejemaal.CreateLejemaalAsync(LejemaalCreateDto lejemaal)
        {
            var lejemaalDtoJson = new StringContent(
                JsonSerializer.Serialize(lejemaal),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PostAsync("/api/Lejemaal", lejemaalDtoJson);
        }

        async Task IServiceLejemaal.DeleteLejemaalAsync(int Id)
        {
            await _client.DeleteAsync($"/api/Lejemaal/{Id}");
        }

        async Task IServiceLejemaal.EditLejemaalAsync(LejemaalDto lejemaal)
        {
            var lejemaalDtoJson = new StringContent(
               JsonSerializer.Serialize(lejemaal),
               Encoding.UTF8,
               MediaTypeNames.Application.Json);
            await _client.PutAsync("/api/Lejemaal", lejemaalDtoJson);
        }

        async Task<LejemaalDto?> IServiceLejemaal.GetLejemaalAsync(int Id)
        {
            return await _client.GetFromJsonAsync<LejemaalDto?>($"/api/Lejemaal/{Id}");
        }

        async Task<IEnumerable<LejemaalDto>> IServiceLejemaal.GetLejemaalAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<LejemaalDto>>($"api/Lejemaal");

        }
    }
}
