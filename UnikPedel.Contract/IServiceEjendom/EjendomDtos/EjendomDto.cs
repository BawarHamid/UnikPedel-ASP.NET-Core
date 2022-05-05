using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceEjendomAnsvarlig.EjendomAnsvarligDtos;

namespace UnikPedel.Contract.IServiceEjendom.EjendomDtos
{
    public class EjendomDto
    {
        public Guid Id { get; set; }
        public string VejNavn { get; set; }
        public int BygningsNummer { get; set; }
        public string PostNummer { get; set; }
        public string By { get; set; }
        public string Region { get; set; }
        public int LandKode { get; set; }

      //  public IEnumerable<Lejemål> Lejemål { get; set; }
        public IEnumerable<EjendomAnsvarligDto> EjendomsAnsvarlig { get; set; }
    }
}
