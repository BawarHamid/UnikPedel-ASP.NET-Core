using UnikPedel.Domain.Entities;

namespace UnikPedel.Application
{
    public class RekvisitionCommandDto
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public DateTime TimeCreated { get; set; }
        public string Status { get; set; }
        public string Beskrivelse { get; set; }



        public int ViceværtId { get; set; }
        public int LejerId { get; set; }

        public int EjendomsId { get; set; }
        
        
        //public Vicevært Vicevært { get; set; }
        //public Lejer Lejer { get; set; }
        //public Ejendom Ejendom { get; set; }


    }

    public class RekvisitionCreateCommandDto
    {
        public string Type { get; set; }
        public DateTime TimeCreated { get; set; }
        public string Status { get; set; }
        public string Beskrivelse { get; set; }



        public int ViceværtId { get; set; }
        //public ViceværtDto Vicevært { get; set; }

        public int LejerId { get; set; }

        //public Lejer Lejer { get; set; }

        public int EjendomsId { get; set; }
        //public EjendomDto Ejendom { get; set; }

    }

}