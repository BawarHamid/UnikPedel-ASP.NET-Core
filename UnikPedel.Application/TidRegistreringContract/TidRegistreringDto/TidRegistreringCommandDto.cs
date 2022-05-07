using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.Entities;

namespace UnikPedel.Application.TidRegistreringContract.TidRegistreringDto
{
   public class TidRegistreringCommandDto
    {
        public Guid Id { get; set; }
        public DateTime RegisterDato { get; set; }

        public double AntalTimer { get; set; }

        public Vicevært Vicevært { get; set; }
        public Rekvisition Rekvisition { get; set; }
    }
}
