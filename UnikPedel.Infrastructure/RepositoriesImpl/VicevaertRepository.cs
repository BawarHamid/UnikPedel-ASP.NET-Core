using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Infrastructure;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.RepositoriesImpl
{
    public class VicevaertRepository : IVicevaertRepository
    {
        private readonly UnikPedelContext _db;
        public VicevaertRepository(UnikPedelContext db)
        {
            _db = db;
        }

        async Task IVicevaertRepository.AddVicevaertAsync(Domain.Entities.Vicevaert vicevaert)
        {
            _db.Vicevaert.Add(vicevaert);
            await _db.SaveChangesAsync();
        }

        async Task IVicevaertRepository.DeleteVicevaertAsync(int Id)
        {
            var vicevaert = _db.Vicevaert.Find(Id);
            if (vicevaert is null) return;

            _db.Vicevaert.Remove(vicevaert);
            await _db.SaveChangesAsync();
        }

        async Task<Domain.Entities.Vicevaert> IVicevaertRepository.GetVicevaertAsync(int Id)
        {
            return await _db.Vicevaert.FindAsync(Id) ?? throw new Exception("Vicevært findes ikke");
        }

        async Task IVicevaertRepository.SaveVicevaertAsync(Domain.Entities.Vicevaert vicevaert)
        {
            _db.Vicevaert.Update(vicevaert);
            await _db.SaveChangesAsync();
        }
    }
}
