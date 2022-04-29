﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class Lejemål
    {
        [Key]
        public Guid Id { get; set; }
        public  string VejNavn {get;set;}
        public  int   BygningsNummer {get; set;}
        public string AndenAdresse {get;set;}
        public string PostNummer {get;set;}
        public string By {get;set;}
        public  string Region {get;set;}
        public int LandNummer {get;set;}
        public  bool IsBookable {get;set;}


        public Ejendom Ejendom { get; set; }

        public Lejer Lejer { get; set; }

        // public IEnumerable<Rekvisition> Rekvisitioner { get; set; }

    }
}
