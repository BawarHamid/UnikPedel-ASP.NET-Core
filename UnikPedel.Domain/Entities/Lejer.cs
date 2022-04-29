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
        public int Id { get; set; }
        [Required]

        public string Navn { get; set; }
        public string EfterNavn { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public int Telefon { get; set; }

        public IEnumerable<Rekvisition> Rekvisitioner { get; set; }

        public IEnumerable<Booking> Bookinger { get; set; }
        public Lejemål Afdeling { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
