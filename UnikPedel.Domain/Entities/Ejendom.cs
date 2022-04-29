using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Ejendom
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public IEnumerable<Lejemål> Afdelinger { get; set; }
    }
}
