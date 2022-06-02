using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceEjendom.EjendomDtos;
using UnikPedel.Contract.VicevaertDtos;

namespace UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos
{
    public class RekvisitionDto
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public DateTime TimeCreated { get; set; }
        public string Status { get; set; }
        public string Beskrivelse { get; set; }

        
        public int VicevaertId { get; set; }
        //public ViceværtDto Vicevært { get; set; }

        public int LejerId { get; set; }
        //public Lejer Lejer { get; set; }

        public int EjendomId { get; set; }
        //public EjendomDto Ejendom { get; set; }
        
    }

    public class RekvisitionCreateDto
    {
        public string Type { get; set; }
        public DateTime TimeCreated { get; set; }
        public string Status { get; set; }
        public string Beskrivelse { get; set; }


        
        public int VicevaertId { get; set; }
        //public ViceværtDto Vicevært { get; set; }

        public int LejerId { get; set; }
        //public Lejer Lejer { get; set; }

        public int EjendomId { get; set; }
        //public EjendomDto Ejendom { get; set; }
        
    }
}
