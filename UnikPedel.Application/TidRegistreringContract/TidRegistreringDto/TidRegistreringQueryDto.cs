using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.Entities;

namespace UnikPedel.Application.TidRegistreringContract.TidRegistreringDto
{
    public class TidRegistreringQueryDto
    {
        public int Id { get; set; }
        public DateTime RegisterDato { get; set; }

        public double AntalTimer { get; set; }

        public int VicevaertId { get; set; }
        public Vicevaert Vicevaert { get; set; }
        public int RekvisitionId { get; set; }
        public Rekvisition Rekvisition { get; set; }
    }
}
