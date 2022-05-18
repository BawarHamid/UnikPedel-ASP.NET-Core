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
        public int Id { get; set; } 
      public int ViceværtId { get; set; }
      //public Vicevært Vicevært { get; set; }

      public int EjendomId { get; set; }
     // public Ejendom Ejendom { get; set; }
      
    }
}
