using System.Net.Mime;
using System.Text;
using System.Text.Json;
using UnikPedel.Contract.IServiceLejer;
using UnikPedel.Contract.IServiceLejer.LejerDtos;

namespace UnikPedel.Web.Infrastructure
{
    public class LejerServiceProxy : ILejerService
    {
        private readonly HttpClient _client;

        public LejerServiceProxy(HttpClient client)
        {
            _client = client;
        }
        public  async Task CreateLejerAsync(LejerCreateDto lejer)
        {
            var lejerDtoJson = new StringContent(
              JsonSerializer.Serialize(lejer),
              Encoding.UTF8,
              MediaTypeNames.Application.Json);
            await _client.PostAsync("/api/Lejer", lejerDtoJson);
        }

        public  async Task DeleteLejerAsync(int Id)
        {
            await _client.DeleteAsync($"/api/Lejer/{Id}");
        }

        public async  Task EditLejerAsync(LejerDto lejer)
        {
            var lejerDtoJson = new StringContent(
            JsonSerializer.Serialize(lejer),
            Encoding.UTF8,
          MediaTypeNames.Application.Json);
            await _client.PutAsync("/api/lejer", lejerDtoJson);
        }

        public async Task<LejerDto?> GetLejerAsync(int Id)
        {
            return await _client.GetFromJsonAsync<LejerDto?>($"/api/Lejer/{Id}");
        }

        public  async Task<IEnumerable<LejerDto>> GetLejereAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<LejerDto>>($"api/Lejer");
        }
    }
}
