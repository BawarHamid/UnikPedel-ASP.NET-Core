using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application.Contract.Dtos
{
    public class ViceværtCommandDto
    {
        public int Id { get; set; }
        public string ForNavn { get; set; }
        public string EfterNavn { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public int ViceværtId { get; set; }
        public int EjendomsId { get; set; }
    }

    public class ViceværtCreateCommandDto
    {
        public string ForNavn { get; set; }
        public string EfterNavn { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public int ViceværtId { get; set; }
        public int EjendomsId { get; set; }
    }
}
