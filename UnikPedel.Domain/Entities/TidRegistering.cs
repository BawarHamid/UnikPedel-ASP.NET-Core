using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
   public class TidRegistering : BaseEntity
    {
       
        public DateTime RegisterDato { get; set; }

        public double AntalTimer { get; set; }

        public int VicevaertId { get; set; }
        public Vicevaert? Vicevaert { get; set; }
        public int RekvisitionId { get; set; }
        public Rekvisition? Rekvisition { get; set; }

        //Constructor for Ef
        private TidRegistering()
        {

        }
        public TidRegistering(double AntalTimer,int VicevaertId,int RekvisitionId)
        {
            this.RegisterDato = DateTime.Now;
            this.AntalTimer = AntalTimer;
            this.VicevaertId = VicevaertId;
            this.RekvisitionId = RekvisitionId;
        }
        //public void RegistrerTid(double ekstraTid)
        //{
        //    RegisterDato = DateTime.Now;
        //    AntalTimer = +ekstraTid;
        //}
        public void Update( DateTime registerDato, double AntalTimer, int VicevaertId, int RekvisitionId)
        {
           this.RegisterDato=registerDato;
            this.AntalTimer = AntalTimer;
            this.VicevaertId = VicevaertId;
            this.RekvisitionId = RekvisitionId;
        }
    }
}
