using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        //public double Pris { get; set; }
        public Lejer Beboer { get; set; }
        public Lejlighed GæsteLejlighed { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
