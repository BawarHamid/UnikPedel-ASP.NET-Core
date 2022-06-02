using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Domain.Entities
{
    public class EjendomsAnsvarlig : BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; private set; }

        public int VicevaertId { get; set; }
        public Vicevaert Vicevaert { get; set; }

        public int EjendomId { get; set; }
        public Ejendom Ejendom { get;  set; }

        // Constractor for EF
        private EjendomsAnsvarlig()
        {

        }

        public EjendomsAnsvarlig( int VicevaertId , int EjendomId)
        {
            this.EjendomId = EjendomId;
            this.VicevaertId = VicevaertId;

        }

        public void Update(int VicevaertId, int EjendomId)
        {
            this.EjendomId = EjendomId;
            this.VicevaertId = VicevaertId;
            
        }
       

     

    }
}
