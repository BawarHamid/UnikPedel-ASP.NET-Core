using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Lejemål : BaseEntity
    {
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public Guid Id { get; set; }
        [Required]
        public  string VejNavn {get;set;}
        public  int   BygningsNummer {get; set;}
        public string AndenAdresse {get;set;}
        public string PostNummer {get;set;}
        public string By {get;set;}
        public  string Region {get;set;}
        public string LandKode {get;set;}
        public  bool IsBookable {get;set;}

        public int EjendomId {get;set;}
        public Ejendom Ejendom { get; set; }

        //public int RekvisitionId { get; set; }
        //public Rekvisition Rekvisition { get; set; }

        public Lejer Lejer { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
      
    }
}
