using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Vicevært
    {
        [Key]
        public Guid Id { get; set; }
        [Required]

        public string ForNavn { get; set; }
        public string EfterNavn { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }

        //public IEnumerable<EjendomsAnsvarlig> EjendomsAnsvarlig { get; set; }
        public EjendomsAnsvarlig EjendomsAnsvarlig { get; set; }
        public IEnumerable<Rekvisition> Rekvisitioner { get; set; }
        public IEnumerable<Ejendom> Ejemdom { get; set; }

        //public Vicevært(string fornavn, string efternavn, int telefon, string email)
        //{
        //    ForNavn = fornavn;
        //    EfterNavn = efternavn;
        //    Telefon = telefon;
        //    Email = email;
        //}
    }
}
