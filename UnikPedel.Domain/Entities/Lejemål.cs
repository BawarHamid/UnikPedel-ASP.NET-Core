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
        public string City {get;set;}
        public  string Region {get;set;}
        public string LandKode {get;set;}
        public  bool IsBookable {get;set;}

        public int EjendomId {get;set;}
        public Ejendom Ejendom { get; set; }
        public Lejer Lejer { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }


        public Lejemål(string vejNavn, int bygningsNummer, string andenAdresse, string postNummer, string city, string region, string landKode, bool isBookable, int ejendomId)
        {
            VejNavn = vejNavn;
            BygningsNummer = bygningsNummer;
            AndenAdresse = andenAdresse;
            PostNummer = postNummer;
            City = city;
            Region = region;
            LandKode = landKode;
            IsBookable = isBookable;
            EjendomId = ejendomId;
        }

        public void Update(string vejNavn, int bygningsNummer, string andenAdresse, string postNummer, string city, string region, string landKode, bool isBookable, int ejendomId)
        {
            VejNavn = vejNavn;
            BygningsNummer = bygningsNummer;
            AndenAdresse = andenAdresse;
            PostNummer = postNummer;
            City = city;
            Region = region;
            LandKode = landKode;
            IsBookable = isBookable;
            EjendomId = ejendomId;
        }
    }
}
