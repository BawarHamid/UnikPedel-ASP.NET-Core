using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.DomainServices;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.DominServiceImpl
{
    public class ViceværtDomainService : IViceværtDomainService
    {
        private readonly UnikPedelContext _db;

        public ViceværtDomainService(UnikPedelContext db)
        {
            _db = db;
        }

        IEnumerable<Domain.Entities.Vicevært> IViceværtDomainService.GetExsistingViceværter()
        {
            return _db.Vicevært.ToList();
        }
    }
}
