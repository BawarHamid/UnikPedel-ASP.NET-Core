using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.Entities;

namespace UnikPedel.Application.EjendomContract.EjendomDto
{
    public class EjendomQueryDto
    {
        public int Id { get; set; }
        public string VejNavn { get; set; }
        public int BygningsNummer { get; set; }
        public string PostNummer { get; set; }
        public string By { get; set; }
        public string Region { get; set; }
        public int LandKode { get; set; }

        public IEnumerable<Lejemaal> Lejemaal { get; set; }
        public IEnumerable<EjendomsAnsvarlig> EjendomsAnsvarlig { get; set; }
       


    }
}
