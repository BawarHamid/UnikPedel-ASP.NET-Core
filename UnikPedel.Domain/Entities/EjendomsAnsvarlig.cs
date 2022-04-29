using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class EjendomsAnsvarlig
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public int ViceværtId { get; set; }
        public Vicevært Vicevært { get; set; }

        public int AfdelingId { get; set; }
        public Lejemål Afdeling { get; set; }
    }
}
