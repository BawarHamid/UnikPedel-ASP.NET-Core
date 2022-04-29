using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Lejlighed
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Adresse { get; set; }

        public Lejemål Afdeling { get; set; }

        public IEnumerable<Booking> Bookinger { get; set; }
    }
}
