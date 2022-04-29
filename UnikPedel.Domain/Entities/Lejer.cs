using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Lejer
    {
        [Key]
        public Guid LejemålId { get; set; }
        [Required]

        public string ForNavn { get; set; }
        public string MellemNavn { get; set; }
        public string EfterNavn { get; set; }
        public string Email { get; set; }
        public int Telefon { get; set; }
        public DateTime MoveInDate { get; init; }
        public DateTime? MoveOutDate { get; init; }

        public IEnumerable<Rekvisition> Rekvisitioner { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }

        public Lejemål Lejemål { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
