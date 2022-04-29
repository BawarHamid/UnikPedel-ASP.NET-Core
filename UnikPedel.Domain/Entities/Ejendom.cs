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
        public  int VejNummer{get;set;}
        public string BygningsNummer {get;set;}
        public string PostNummer{get;set;}
        public string By {get;set;}
        public string Region {get;set;}
        public int  LandNummer {get;set;}
        
        public IEnumerable<Lejemål> Lejemål { get; set; }
        public IEnumerable<EjendomsAnsvarlig> EjendomsAnsvarlig { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }

    
    }
}
