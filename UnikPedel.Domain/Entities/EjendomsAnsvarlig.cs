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
        //public string ForNavn { get; set; }
        //public string EfterNavn { get; set; }
        //public int Telefon { get; set; }
        //public string Email { get; set; }

        public Guid ViceværtId { get; set; }
        public IEnumerable<Vicevært> Vicevært { get; set; }
        //public Vicevært Vicevært { get; set; }

        public Guid EjendomId { get; set; }
        //public Ejendom Ejendom { get; set; }
        public IEnumerable<Ejendom> Ejendom { get; set; }

    }
}
