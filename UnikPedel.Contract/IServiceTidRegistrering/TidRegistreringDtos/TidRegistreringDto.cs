using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;
using UnikPedel.Contract.VicevaertDtos;

namespace UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos
{
    public class TidRegistreringDto
    {
        public int Id { get; set; }
        public DateTime RegisterDato { get; set; }

        public double AntalTimer { get; set; }
        public int VicevaertId { get; set; }
     //   public ViceværtDto Vicevært { get; set; }
        public int RekvisitionId { get; set; }
      //  public RekvisitionDto Rekvistion { get; set; }
    }
        
    public class TidRegistreringCreateDto
        {
            public DateTime RegisterDato { get; set; }

            public double AntalTimer { get; set; }
            public int VicevaertId { get; set; }
            public int RekvisitionId { get; set; }
        }

    }

