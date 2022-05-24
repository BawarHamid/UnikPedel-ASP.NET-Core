using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Contract.IServiceLejer.LejerDtos
{
    public class LejerDto
    {
        public int Id { get; set; }
        public string ForNavn { get; set; }
        public string MellemNavn { get; set; }
        public string EfterNavn { get; set; }
        public string Email { get; set; }
        public int Telefon { get; set; }
        public DateTime IndDato { get; init; }
        public DateTime? UdDato { get; init; }
        public int LejemålId { get; set; }
    }

    public class LejerCreateDto
    {
        public string ForNavn { get; set; }
        public string MellemNavn { get; set; }
        public string EfterNavn { get; set; }
        public string Email { get; set; }
        public int Telefon { get; set; }
        public DateTime IndDato { get; init; }
        public DateTime? UdDato { get; init; }
        public int LejemålId { get; set; }
    }
}
