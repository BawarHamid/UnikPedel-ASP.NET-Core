using UnikPedel.Domain.Entities;

namespace UnikPedel.Application
{
    public class RekvisitionCommandDto
    {
        public Guid Id { get; set; }
   
        public string Type { get; set; }
        public DateTime TimeCreated { get; set; }
        public string Status { get; set; }
        public string Beskrivelse { get; set; }

        public Vicevært Vicevært { get; set; }
        public Lejer Lejer { get; set; }
        public EjendomCommandDto Ejendom { get; set; }
    }
}