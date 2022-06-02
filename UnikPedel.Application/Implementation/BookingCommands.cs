


using UnikPedel.Application.BookingContract;
using UnikPedel.Application.BookingContract.BookingDto;
using UnikPedel.Application.Infrastructure;

namespace UnikPedel.Application.Implementation;

public class BookingCommand : IBookingCommand
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IBookingRepository _repository;

    public BookingCommand(IServiceProvider serviceProvider, IBookingRepository repository)
    {
        _serviceProvider = serviceProvider;
        _repository = repository;
    }

    async Task IBookingCommand.CreateAsync(BookingCommandDto bookingDto)
    {
        var booking = new UnikPedel.Domain.Entities.Booking(_serviceProvider, bookingDto.StartTid, bookingDto.SlutTid,bookingDto.LejerId,bookingDto.LejemaalId);
        await _repository.AddAsync(booking);
    }

    async Task IBookingCommand.DeleteAsync(BookingCommandDto bookingDto)
    {
        await _repository.DeleteAsync(bookingDto.Id);
    }

    async Task IBookingCommand.EditAsync(BookingCommandDto bookingDto)
    {
        var booking = await _repository.GetAsync(bookingDto.Id);
      booking._serviceProvider = _serviceProvider;
        booking.Update(bookingDto.StartTid, bookingDto.SlutTid,booking.LejemaalId);
        await _repository.SaveAsync(booking);
    }
}