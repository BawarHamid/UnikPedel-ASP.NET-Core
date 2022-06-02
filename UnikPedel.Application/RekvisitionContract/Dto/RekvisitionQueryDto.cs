using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.Entities;

namespace UnikPedel.Application
{
    public class RekvisitionQueryDto
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public DateTime TimeCreated{ get; set; }
        public string Status { get; set; }
        public string Beskrivelse { get; set; }

        public int   VicevaertId { get; set; }
        public Vicevaert Vicevaert { get; set; }

        public Lejer Lejer { get; set; }
        public int LejerId { get; set; }

        public int EjendomId { get; set; }
        public Ejendom Ejendom { get; set; }
    }
}
