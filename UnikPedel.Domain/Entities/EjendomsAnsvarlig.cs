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
        public Guid Id { get; set; }
     
        public Guid ViceværtId { get; set; }
        public IEnumerable<Vicevært> Vicevært { get; set; }
     
        public Guid EjendomId { get; set; }
        public IEnumerable<Ejendom> Ejendom { get; set; }

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
