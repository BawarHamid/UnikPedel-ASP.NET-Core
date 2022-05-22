



using UnikPedel.Application.BookingContract.BookingDto;

namespace UnikPedel.Application.BookingContract;

public interface IBookingCommand
{
    Task CreateAsync(BookingCommandDto bookingDto);
    Task EditAsync(BookingCommandDto bookingDto);
    Task DeleteAsync(BookingCommandDto bookingDto);
}