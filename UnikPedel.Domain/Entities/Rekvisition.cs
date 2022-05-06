﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Rekvisition
    {
        [Key]
        public Guid Id { get; set; }
        

        public string Type { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime TimeCreated { get; set; }
        public string Status { get; set; }

        public Vicevært Vicevært { get; set; }
        public Lejer Lejer { get; set; }
        public Ejendom Ejendom {get;set; }

        [Timestamp]
        public byte[] Version { get; set; }


        public Rekvisition(string type, string status, string beskrivelse, Vicevært vicevært, Lejer lejer, Ejendom ejendom)
        {
            Type = type;
            TimeCreated = DateTime.Now;
            Status = status;
            Beskrivelse = beskrivelse;
            Vicevært = vicevært;
            Lejer = lejer;
            Ejendom = ejendom;

        }

        public void Update(string type,  string status, string beskrivelse, Vicevært vicevært, Lejer lejer, Ejendom ejendom)
        {
            Type = type;
            Status = status;
            Beskrivelse = beskrivelse;
            Vicevært = vicevært;
            Lejer = lejer;
            Ejendom = ejendom;

        }
    }

}
