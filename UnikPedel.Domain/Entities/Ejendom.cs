using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Ejendom : BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }

        public  string VejNavn{get;set;}
        public int BygningsNummer {get;set;}
        public string PostNummer{get;set;}
        public string By {get;set;}
        public string Region {get;set;}
        public int  LandKode {get;set;}
        
        public IEnumerable<Lejemaal> Lejemaal { get; set; }
        //public EjendomsAnsvarlig EjendomsAnsvarlig { get; set; }
        public IEnumerable<EjendomsAnsvarlig> EjendomsAnsvarlig { get; set; }
        public IEnumerable<Rekvisition> Rekvisitioner { get; set; }
        public IEnumerable<Vicevaert> Vicevaert { get; set; }
    }
}
