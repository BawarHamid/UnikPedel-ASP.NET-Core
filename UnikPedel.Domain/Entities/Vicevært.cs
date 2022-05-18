using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Vicevært : BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }

        [Required]

        public string ForNavn { get; set; }
        public string EfterNavn { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }

        //public IEnumerable<EjendomsAnsvarlig> EjendomsAnsvarlig { get; set; }
        //public int EjendomsAnsvarligId { get; set; }
        public IEnumerable<EjendomsAnsvarlig> EjendomsAnsvarlig { get; set; }
        public IEnumerable<Rekvisition> Rekvisitioner { get; set; }
        public IEnumerable<EjendomCommandDto> Ejemdom { get; set; }
        public IEnumerable<TidRegistering> TidRegistrering { get; set; }

        //Constructor for Ef
        private Vicevært()
        {

        }
        public Vicevært(string fornavn, string efternavn, int telefon, string email)
        {
            ForNavn = fornavn;
            EfterNavn = efternavn;
            Telefon = telefon;
            Email = email;
        }

        public void Update(string fornavn, string efternavn, int telefon, string email)
        {
            ForNavn = fornavn;
            EfterNavn = efternavn;
            Telefon = telefon;
            Email = email;
        }
    }
}
