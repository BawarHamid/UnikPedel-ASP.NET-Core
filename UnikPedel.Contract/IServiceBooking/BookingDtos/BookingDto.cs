using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Contract.IServiceBooking.BookingDtos
{
 public class BookingDto
    {
        public int Id { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public int LejerId { get; set; }

        public int LejemålId { get; set; }
    }

    public class BookingCreateBookingDto
    {
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public int LejerId { get; set; }

        public int LejemålId { get; set; }

    }
}
