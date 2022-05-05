using UnikPedel.Domain.Entities;

namespace UnikPedel.Application
{
    public class RekvisitionCommandDto
    {
        public Guid Id { get; set; }
   
        public string Type { get; set; }
        public double AntalTimer { get; set; }
        public string Status { get; set; }
        public string Beskrivelse { get; set; }

        public Vicevært Vicevært { get; set; }
        public Lejer Lejer { get; set; }
        public Ejendom Ejendom { get; set; }
    }
}