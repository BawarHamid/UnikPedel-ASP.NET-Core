using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application.Contract.Dtos
{
    public class ViceværtQueryDto
    {
        public int Id { get; set; }
        public string ForNavn { get; set; }
        public string EfterNavn { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
    }
}
