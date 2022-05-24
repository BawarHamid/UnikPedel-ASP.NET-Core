using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Lejer : BaseEntity
    {
    //    [Key]
    //    public Guid LejemålId { get; set; }
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]

        public string ForNavn { get; set; }
        public string MellemNavn { get; set; }
        public string EfterNavn { get; set; }
        public string Email { get; set; }
        public int Telefon { get; set; }
        public DateTime IndDato { get; init; }
        public DateTime? UdDato { get; init; }


        public IEnumerable<Rekvisition> Rekvisitioner { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public int LejemålId { get; set; }
        public Lejemål Lejemål { get; set; }

        public Lejer(string forNavn, string mellemNavn, string efterNavn, string email, int telefon, DateTime indDato, DateTime? udDato, int lejemålId)
        {
            ForNavn = forNavn;
            MellemNavn = mellemNavn;
            EfterNavn = efterNavn;
            Email = email;
            Telefon = telefon;
            IndDato = indDato;
            UdDato = udDato;
            LejemålId = lejemålId;
        }

        public void Update(string forNavn, string mellemNavn, string efterNavn, string email, int telefon, DateTime indDato, DateTime? udDato, int lejemålId)
        {
            ForNavn = forNavn;
            MellemNavn = mellemNavn;
            EfterNavn = efterNavn;
            Email = email;
            Telefon = telefon;
            indDato = IndDato;
            udDato = UdDato;
            LejemålId = lejemålId;
        }
    }
}
