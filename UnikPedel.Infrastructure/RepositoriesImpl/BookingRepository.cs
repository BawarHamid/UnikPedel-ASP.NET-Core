
using UnikPedel.Application.Infrastructure;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.RepositoriesImpl;

public class BookingRepository : IBookingRepository
{
    private readonly UnikPedelContext _db;

    public BookingRepository(UnikPedelContext db)
    {
        _db = db;
    }

    async Task IBookingRepository.AddAsync(UnikPedel.Domain.Entities.Booking booking)
    {
        _db.Booking.Add(booking);
        await _db.SaveChangesAsync();
    }

    async Task IBookingRepository.DeleteAsync(int id)
    {
        var booking = _db.Booking.Find(id);
        if (booking is null) return;

        _db.Booking.Remove(booking);
        await _db.SaveChangesAsync();
    }

    async Task<Domain.Entities.Booking> IBookingRepository.GetAsync(int id)
    {
        return await _db.Booking.FindAsync(id) ?? throw new Exception("Booking not found");
    }

    async Task IBookingRepository.SaveAsync(Domain.Entities.Booking booking)
    {
        _db.Booking.Update(booking);
        await _db.SaveChangesAsync();
    }
}