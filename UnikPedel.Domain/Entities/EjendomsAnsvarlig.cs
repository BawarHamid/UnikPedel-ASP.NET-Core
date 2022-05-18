using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class EjendomsAnsvarlig
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; private set; }

        public int ViceværtId { get; set; }
        public Vicevært Vicevært { get; set; }

        public int EjendomId { get; set; }
        public Ejendom Ejendom { get;  set; }

        // Constractor for EF
        private EjendomsAnsvarlig()
        {

        }

        public EjendomsAnsvarlig( Vicevært Vicevært, Ejendom Ejendom)
        {
            
            //this.Ejendom = Ejendom;
            //this.Vicevært = Vicevært;
        }

        public void Update( Vicevært Vicevært, Ejendom Ejendom)
        {

            //this.Ejendom = Ejendom;
            //this.Vicevært = Vicevært;
        }

     

    }
}
