using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.Entities;

namespace UnikPedel.Application.EjendomsAnsvarligContract.EjendomsAnsvarligDto
{
    public class EjendomsAnsvarligQueryDto
    {
        public Guid Id { get; set; }

        public Guid ViceværtId { get; set; }
        public IEnumerable<Vicevært> Vicevært { get; set; }

        public Guid EjendomId { get; set; }
        public IEnumerable<Ejendom> Ejendom { get; set; }
    }
}
