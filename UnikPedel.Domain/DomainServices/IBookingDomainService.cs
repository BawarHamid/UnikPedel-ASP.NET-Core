using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.DomainServices
{
    public interface IBookingDomainService
    {
        IEnumerable<Entities.Booking> GetExsistingBookings();
    }
}
