using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceEjendom.EjendomDtos;
using UnikPedel.Contract.VicevaertDtos;

namespace UnikPedel.Contract.IServiceEjendomAnsvarlig.EjendomAnsvarligDtos
{
    public class EjendomAnsvarligDto
    {
        public int Id { get; set; }
        public int VicevaertId { get; set; }
       // public ViceværtDto Vicevært { get; set; }


      public int EjendomId { get; set; }
        //public EjendomDto Ejendom { get; set; }
    }
    public class EjendomAnsvarligCreateDto
    {

      
        public int VicevaertId { get; set; }
       

        public int EjendomId { get; set; }
     
    }
}
