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
        public Guid Id { get; set; }
        [Required]

        public  int VejNavn{get;set;}
        public int BygningsNummer {get;set;}
        public string PostNummer{get;set;}
        public string By {get;set;}
        public string Region {get;set;}
        public string  LandKode {get;set;}
        
        public IEnumerable<Lejemål> Lejemål { get; set; }
        public EjendomsAnsvarlig EjendomsAnsvarlig { get; set; }
        //public IEnumerable<EjendomsAnsvarlig> EjendomsAnsvarlig { get; set; }
        public IEnumerable<Rekvisition> Rekvisitioner { get; set; }
        public IEnumerable<Vicevært> Vicevært { get; set; }
    }
}
