using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Booking : BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }
        [Required]

        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

       
        public int LejerId { get; set; }
        public Lejer Lejer { get; set; }

        public int LejemålId {get;set;}
        public Lejemål Lejemål {get;set; }

        //public Vicevært Vicevært {get;set;}

        [Timestamp]
        public byte[] Version { get; set; } 
    }
}
