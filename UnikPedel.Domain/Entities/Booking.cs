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
        public Guid Id { get; set; }
        [Required]

        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

       
        public Lejer Lejer { get; set; }
        public Lejemål Lejemål {get;set;}
        public Vicevært Vicevært {get;set;}

        [Timestamp]
        public byte[] Version { get; set; } 
    }
}
