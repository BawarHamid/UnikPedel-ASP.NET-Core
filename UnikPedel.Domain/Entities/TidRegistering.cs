using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
   public class TidRegistering : BaseEntity
    {
        //public Guid Id { get; set; }
        public DateTime RegisterDato { get; set; }

        public double AntalTimer { get; set; }

        public Vicevært? Vicevært { get; set; }
        public Rekvisition? Rekvisition { get; set; }

        //Constructor for Ef
        private TidRegistering()
        {

        }
        public TidRegistering(double AntalTimer,Vicevært Vicevært,Rekvisition Rekvisition)
        {
            this.RegisterDato = DateTime.Now;
            this.AntalTimer = AntalTimer;
            this.Vicevært = Vicevært;
            this.Rekvisition = Rekvisition;
        }
        public void RegistrerTid(double ekstraTid)
        {
            RegisterDato = DateTime.Now;
            AntalTimer = +ekstraTid;
        }
        public void Update(double AntalTimer, Vicevært Vicevært, Rekvisition Rekvisition)
        {
            this.AntalTimer = AntalTimer;
            this.Vicevært = Vicevært;
            this.Rekvisition = Rekvisition;
        }
    }
}
