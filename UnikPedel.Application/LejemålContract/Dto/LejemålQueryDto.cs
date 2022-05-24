using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.Entities;

namespace UnikPedel.Application.LejemålContract.Dto
{

    public class LejemålQueryDto
    {
        public int Id { get; set; }

        public string VejNavn { get; set; }

        public int BygningNummer { get; set; }

        public string AndenAdresse { get; set; }

        public string PostNummer { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string LandKode { get; set; }

        public bool IsBookable { get; set; }
        public int EjendomId { get; set; }
    }
}
