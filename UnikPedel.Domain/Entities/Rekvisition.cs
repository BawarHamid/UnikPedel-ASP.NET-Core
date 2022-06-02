using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Rekvisition : BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }
        

        public string Type { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime TimeCreated { get; set; }
        public string Status { get; set; }

        public int VicevaertId { get; set; }
        public Vicevaert Vicevaert { get; set; }

        public int LejerId { get; set; }
        public Lejer Lejer { get; set; }

        public int EjendomId {get;set; }
        public Ejendom Ejendom {get;set; }

        public IEnumerable<TidRegistering> TidRegistering { get; set; }
        //public IEnumerable<Lejemål> Lejemål { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

      

        public Rekvisition(string type, string status, string beskrivelse, int vicevaertId, int lejerId, int ejendomId)
        {
            Type = type;
            TimeCreated = DateTime.Now;
            Status = status;
            Beskrivelse = beskrivelse;
            VicevaertId = vicevaertId;
            LejerId = lejerId;
            EjendomId = ejendomId;

        }

        public void Update(string type,  string status, string beskrivelse, int vicevaertId, int lejerId, int ejendomId)
        {
            Type = type;
            Status = status;
            Beskrivelse = beskrivelse;
            VicevaertId = vicevaertId;
            LejerId = lejerId;
            EjendomId = ejendomId;
        }
    }
}
