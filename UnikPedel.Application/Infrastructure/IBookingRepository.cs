

namespace UnikPedel.Application.Infrastructure;

public interface IBookingRepository
{
    Task AddAsync(UnikPedel.Domain.Entities.Booking booking);
    Task<UnikPedel.Domain.Entities.Booking> GetAsync(int id);
    Task SaveAsync(UnikPedel.Domain.Entities.Booking booking);
    Task DeleteAsync(int id);
}