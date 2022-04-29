using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Rekvisition
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Type { get; set; }
        public double AntalTimer { get; set; }
        public string Status { get; set; }
        public string Beskrivelse { get; set; }

        public Vicevært Vicevært { get; set; }
        // public Afdeling Afdeling { get; set; }
        public Lejer Beboer { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
