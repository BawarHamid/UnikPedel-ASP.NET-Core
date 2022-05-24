using System.Net.Mime;
using System.Text;
using System.Text.Json;
using UnikPedel.Contract.IServiceLejmål;
using UnikPedel.Contract.IServiceLejmål.LejemålDtos;

namespace UnikPedel.Web.Infrastructure
{
    public class LejemålServiceProxy : IServiceLejemål
    {
        private readonly HttpClient _client;
        public LejemålServiceProxy(HttpClient client)
        {
            _client = client;
        }

        async Task IServiceLejemål.CreateLejemålAsync(LejemålCreateDto lejemål)
        {
            var lejemålDtoJson = new StringContent(
                JsonSerializer.Serialize(lejemål),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PostAsync("/api/Lejemål", lejemålDtoJson);
        }

        async Task IServiceLejemål.DeleteLejemålAsync(int Id)
        {
            await _client.DeleteAsync($"/api/Lejemål/{Id}");
        }

        async Task IServiceLejemål.EditLejemålAsync(LejemålDto lejemål)
        {
            var lejemålDtoJson = new StringContent(
               JsonSerializer.Serialize(lejemål),
               Encoding.UTF8,
               MediaTypeNames.Application.Json);
            await _client.PutAsync("/api/Lejemål", lejemålDtoJson);
        }

        async Task<LejemålDto?> IServiceLejemål.GetLejemålAsync(int Id)
        {
            return await _client.GetFromJsonAsync<LejemålDto?>($"/api/Lejemål/{Id}");
        }

        async Task<IEnumerable<LejemålDto>> IServiceLejemål.GetLejemålAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<LejemålDto>>($"api/Lejemål");

        }
    }
}
