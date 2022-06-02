using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application.LejemaalContract.Dto
{
    public class LejemaalCommandDto
    {
        public int Id { get; set; }
        public string VejNavn { get; set; }
        public int BygningsNummer { get; set; }
        public string AndenAdresse { get; set; }
        public string PostNummer { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string LandKode { get; set; }
        public bool IsBookable { get; set; }

        public int EjendomId { get; set; }
    }

    public class LejemålCreateCommandDto
    {

        public string VejNavn { get; set; }
        public int BygningsNummer { get; set; }
        public string AndenAdresse { get; set; }
        public string PostNummer { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string LandKode { get; set; }
        public bool IsBookable { get; set; }

        public int EjendomId { get; set; }
    }
}
