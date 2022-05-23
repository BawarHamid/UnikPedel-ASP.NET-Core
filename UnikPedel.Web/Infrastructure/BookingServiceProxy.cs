using System.Net.Mime;
using System.Text;
using System.Text.Json;
using UnikPedel.Contract.IServiceBooking;
using UnikPedel.Contract.IServiceBooking.BookingDtos;

namespace UnikPedel.Web.Infrastructure
{
    public class BookingServiceProxy : IServiceBooking
    {
        private readonly HttpClient _client;

        public BookingServiceProxy(HttpClient client)
        {
            _client = client;
        }

        async Task IServiceBooking.CreateAsync(BookingCreateDto bookingDto)
        {
            var bookingDtoJson = new StringContent(
                JsonSerializer.Serialize(bookingDto),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PostAsync("/api/Booking", bookingDtoJson);
        }

        async Task IServiceBooking.DeleteAsync(int id)
        {

            await _client.DeleteAsync($"/api/Booking/{id}");
        }

        async Task IServiceBooking.EditAsync(BookingDto bookingDto)
        {
            var bookingDtoson = new StringContent(
                JsonSerializer.Serialize(bookingDto),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PutAsync("/api/Booking", bookingDtoson);
        }

        async Task<BookingDto?> IServiceBooking.GetBookingAsync(int Id)
        {
            return await _client.GetFromJsonAsync<BookingDto?>($"api/Booking/{Id}");
        }

        async Task<IEnumerable<BookingDto>> IServiceBooking.GetBookingsAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<BookingDto>>($"api/Booking");
        }
    }
}
