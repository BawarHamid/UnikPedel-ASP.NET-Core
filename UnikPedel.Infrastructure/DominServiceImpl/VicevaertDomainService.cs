using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.DomainServices;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.DominServiceImpl
{
    public class VicevaertDomainService : IVicevaertDomainService
    {
        private readonly UnikPedelContext _db;

        public VicevaertDomainService(UnikPedelContext db)
        {
            _db = db;
        }

        IEnumerable<Domain.Entities.Vicevaert> IVicevaertDomainService.GetExsistingVicevaerter()
        {
            return _db.Vicevaert.ToList();
        }
    }
}
