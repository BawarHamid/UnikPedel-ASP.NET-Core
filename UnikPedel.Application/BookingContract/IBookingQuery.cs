

using UnikPedel.Application.BookingContract.BookingDto;


namespace UnikPedel.Application.BookingContract;

public interface IBookingQuery
{
    Task<BookingQueryDto?> GetBookingAsync(int id);
    Task<IEnumerable<BookingQueryDto>> GetBookingsAsync();

    Task<IEnumerable<BookingQueryDto>> GetBookingsForLejerAsync(int Id);
}