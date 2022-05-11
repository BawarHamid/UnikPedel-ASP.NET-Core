using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class EjendomsAnsvarlig
    {
        [Key]
        public Guid Id { get; private set; }
     
        public Guid ViceværtId { get; private set; }
        public IEnumerable<Vicevært> Vicevært { get; set; }
     
       public Guid EjendomId { get; private set; }
        public IEnumerable<Ejendom> Ejendom { get;  set; }

        // Constractor for EF
        private EjendomsAnsvarlig()
        {

        }

        public EjendomsAnsvarlig( IEnumerable<Vicevært> Vicevært, IEnumerable<Ejendom> Ejendom)
        {
            
            this.Ejendom = Ejendom;
            this.Vicevært = Vicevært;
        }

        public void Update( IEnumerable<Vicevært> Vicevært, IEnumerable<Ejendom> Ejendom)
        {

            this.Ejendom = Ejendom;
            this.Vicevært = Vicevært;
        }

     

    }
}
