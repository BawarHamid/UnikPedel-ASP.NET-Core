using System.Net.Mime;
using System.Text;
using System.Text.Json;
using UnikPedel.Contract.IServiceEjendomAnsvarlig;
using UnikPedel.Contract.IServiceEjendomAnsvarlig.EjendomAnsvarligDtos;

namespace UnikPedel.Web.Infrastructure
{
    public class EjendomAnsvarligServiceProxy : IServiceEjendomAnsvarlig
    {
        private readonly HttpClient _client;

        public EjendomAnsvarligServiceProxy(HttpClient client)
        {
            _client = client;
        }

        async Task IServiceEjendomAnsvarlig.CreateEjendomAnsvarligAsync(EjendomAnsvarligCreateDto ejendomAnsvarlig)
        {
            var EjenAnsvarDtoJson = new StringContent(
                JsonSerializer.Serialize(ejendomAnsvarlig),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PostAsync("/api/EjendomAnsvarlig", EjenAnsvarDtoJson);
        }

        async Task IServiceEjendomAnsvarlig.DeleteEjendomAnsvarligAsync(int Id)
        {
            await _client.DeleteAsync($"/api/EjendomAnsvarlig/{Id}");
        }

        async Task IServiceEjendomAnsvarlig.EditEjendomAnsvarligAsync(EjendomAnsvarligDto ejendomAnsvarlig)
        {
            var EjenAnsvarDtoJson = new StringContent(
               JsonSerializer.Serialize(ejendomAnsvarlig),
               Encoding.UTF8,
               MediaTypeNames.Application.Json);
            await _client.PutAsync("/api/EjendomAnsvarlig", EjenAnsvarDtoJson);
        }

        async Task<EjendomAnsvarligDto?> IServiceEjendomAnsvarlig.GetEjendomAnsvarligAsync(int Id)
        {
            return await _client.GetFromJsonAsync<EjendomAnsvarligDto>($"/api/EjendomAnsvarlig/{Id}");
        }

        async Task<IEnumerable<EjendomAnsvarligDto>> IServiceEjendomAnsvarlig.GetEjendomAnsvarligAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<EjendomAnsvarligDto>>($"api/EjendomAnsvarlig");
        }
    }
}
