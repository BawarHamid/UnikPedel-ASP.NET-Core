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
        public Guid Id { get; set; }
        [Required]
        
        public Guid ViceværtId { get; set; }
        public Vicevært Vicevært { get; set; }

        public Guid EjendomId { get; set; }
        public Ejendom Ejendom { get; set; }
    }
}
