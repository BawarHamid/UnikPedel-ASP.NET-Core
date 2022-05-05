using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceEjendom.EjendomDtos;
using UnikPedel.Contract.ViceværtDtos;

namespace UnikPedel.Contract.IServiceEjendomAnsvarlig.EjendomAnsvarligDtos
{
    public class EjendomAnsvarligDto
    {
        public Guid Id { get; set; }

        public Guid ViceværtId { get; set; }
        public IEnumerable<ViceværtDto> Vicevært { get; set; }

        public Guid EjendomId { get; set; }
        public IEnumerable<EjendomDto> Ejendom { get; set; }
    }
}
