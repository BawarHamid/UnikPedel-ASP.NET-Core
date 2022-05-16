using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Contract.ViceværtDtos
{
   public class ViceværtDto
    {
        public int Id { get; set; }
        public string ForNavn { get; set; }
        public string EfterNavn { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
    }

    public class ViceværtCreateDto
    {
        public string ForNavn { get; set; }
        public string EfterNavn { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
    }
}
