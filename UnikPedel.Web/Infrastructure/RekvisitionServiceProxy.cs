using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;

namespace UnikPedel.Web.Infrastructure
{
    //public class RekvisitionServiceProxy : IServiceRekvisition
    //{
    //    private readonly HttpClient _client;

    //    public RekvisitionServiceProxy(HttpClient client)
    //    {
    //        _client = client;
    //    }

    //    async Task IServiceRekvisition.CreateRekvisitionAsync(RekvisitionCreateDto rekvisition)
    //    {
    //        var rekvisitionDtoJson = new StringContent(
    //            JsonSerializer.Serialize(rekvisition),
    //            Encoding.UTF8,
    //            MediaTypeNames.Application.Json);
    //        await _client.PostAsync("/api/Rekvisition", rekvisitionDtoJson);
    //    }

    //    async Task IServiceRekvisition.DeleteRekvisitionAsync(int Id)
    //    {
    //        await _client.DeleteAsync($"/api/Rekvisition/{Id}");
    //    }

    //    async Task IServiceRekvisition.EditRekvisitionAsync(RekvisitionDto rekvisition)
    //    {
    //        var rekvisitionDtoJson = new StringContent(
    //           JsonSerializer.Serialize(rekvisition),
    //           Encoding.UTF8,
    //           MediaTypeNames.Application.Json);
    //        await _client.PutAsync("/api/Rekvisition", rekvisitionDtoJson);
    //    }

    //    async Task<RekvisitionDto?> IServiceRekvisition.GetRekvisitionAsync(int Id)
    //    {
    //        return await _client.GetFromJsonAsync<RekvisitionDto?>($"/api/Rekvisition/{Id}");
    //    }

    //    async Task<IEnumerable<RekvisitionDto>> IServiceRekvisition.GetRekvisitionerAsync()
    //    {
    //        return await _client.GetFromJsonAsync<IEnumerable<RekvisitionDto>>($"api/Rekvisition");
    //    }
    //}
}
