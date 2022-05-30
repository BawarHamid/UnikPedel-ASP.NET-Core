using UnikPedel.Contract.IServiceBooking;
using UnikPedel.Contract.IServiceBooking.BookingDtos;

namespace UnikPedel.Web.Infrastructure
{
    public class BookingLejerServiceProxy : IServiceBookingLejer
    {
        private readonly HttpClient _client;
        public BookingLejerServiceProxy( HttpClient client)
        {
            _client=client; 
        }
        public async  Task<IEnumerable<BookingDto>> GetBookingForLejerAsync(int Id)
        {
            return await _client.GetFromJsonAsync<IEnumerable<BookingDto>>($"api/BookingLejer/{Id}");
        }
    }
}
