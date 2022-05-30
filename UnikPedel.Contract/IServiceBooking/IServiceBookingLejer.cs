using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceBooking.BookingDtos;
using UnikPedel.Contract.IServiceLejer.LejerDtos;

namespace UnikPedel.Contract.IServiceBooking
{
    public interface IServiceBookingLejer
    {
         Task<IEnumerable<BookingDto>> GetBookingForLejerAsync(int Id);
     
    }
}
