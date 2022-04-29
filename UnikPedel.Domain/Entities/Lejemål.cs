using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Lejemål
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Navn { get; set; }
        public Ejendom Ejendom { get; set; }
        public IEnumerable<EjendomsAnsvarlig> EjendomsAnsvarlig { get; set; }

        public IEnumerable<Lejlighed> Lejligheder { get; set; }
        public IEnumerable<Lejer> Lejer { get; set; }

        // public IEnumerable<Rekvisition> Rekvisitioner { get; set; }

    }
}
