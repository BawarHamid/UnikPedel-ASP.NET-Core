using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.DomainServices;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.DominServiceImpl
{
    public class BookingDomainService:IBookingDomainService
    {
        private readonly UnikPedelContext _db;

        public BookingDomainService(UnikPedelContext db)
        {
            _db = db;
        }
        IEnumerable<Domain.Entities.Booking> IBookingDomainService.GetExsistingBookings()
        {
            return _db.Booking.ToList();
        }
    }
}
