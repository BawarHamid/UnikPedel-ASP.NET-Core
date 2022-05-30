
using Microsoft.EntityFrameworkCore;
using UnikPedel.Application.BookingContract;
using UnikPedel.Application.BookingContract.BookingDto;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.Queries
;
public class BookingQuery : IBookingQuery
{
    private readonly UnikPedelContext _db;

    public BookingQuery(UnikPedelContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<BookingQueryDto>> GetBookingsForLejerAsync(int Id)
    {
        var result = new List<BookingQueryDto>();
        var v =  await _db.Lejer.Include(a=> a.Bookings).FirstOrDefaultAsync(b=> b.Id == Id);
        var bookingl= v.Bookings.ToList();
        bookingl.ForEach(a => result.Add(new BookingQueryDto
        {
            Id = a.Id,
            StartTid = a.StartTid,
            SlutTid = a.SlutTid,
            LejemålId = a.LejemålId,
            LejerId = a.LejerId
        }));
        return result;
    }

    async Task<BookingQueryDto?> IBookingQuery.GetBookingAsync(int id)
    {
        var result = await _db.Booking.FindAsync(id);
        if (result is null) return new BookingQueryDto();

        return new BookingQueryDto
        {
            Id = result.Id,
            StartTid = result.StartTid,
            SlutTid = result.SlutTid,
            LejemålId = result.LejemålId,   
            LejerId = result.LejerId   
        };
    }

    async Task<IEnumerable<BookingQueryDto>> IBookingQuery.GetBookingsAsync()
    {
        var result = new List<BookingQueryDto>();
        var dbBookings = await _db.Booking.ToListAsync();
        dbBookings.ForEach(a => result.Add(new BookingQueryDto
        {
            Id = a.Id,
            StartTid = a.StartTid,
            SlutTid = a.SlutTid,
            LejemålId = a.LejemålId,
            LejerId = a.LejerId
        }));
        return result;
    }
}