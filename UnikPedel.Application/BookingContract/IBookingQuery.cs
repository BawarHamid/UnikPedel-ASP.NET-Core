

using UnikPedel.Application.BookingContract.BookingDto;


namespace UnikPedel.Application.BookingContract;

public interface IBookingQuery
{
    Task<BookingQueryDto?> GetBookingAsync(Guid id);
    Task<IEnumerable<BookingQueryDto>> GetBookingsAsync();
}