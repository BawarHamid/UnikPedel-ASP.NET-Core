using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceBooking.BookingDtos;

namespace UnikPedel.Contract.IServiceBooking
{
    public interface IServiceBooking
    {
        Task CreateAsync(BookingCreateBookingDto booking);
        Task EditAsync(BookingDto booking);
        Task DeleteAsync(int Id);
        Task<BookingDto?> GetBookingAsync(int Id);
        Task<IEnumerable<BookingDto>> GetBookingsAsync();
    }


}