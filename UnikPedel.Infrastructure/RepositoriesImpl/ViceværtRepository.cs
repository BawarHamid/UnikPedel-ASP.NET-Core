using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Infrastructure;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.RepositoriesImpl
{
    public class ViceværtRepository : IViceværtRepository
    {
        private readonly UnikPedelContext _db;
        public ViceværtRepository(UnikPedelContext db)
        {
            _db = db;
        }

        async Task IViceværtRepository.AddViceværtAsync(Domain.Entities.Vicevært vicevært)
        {
            _db.Vicevært.Add(vicevært);
            await _db.SaveChangesAsync();
        }

        async Task IViceværtRepository.DeleteViceværtAsync(int Id)
        {
            var vicevært = _db.Vicevært.Find(Id);
            if (vicevært is null) return;

            _db.Vicevært.Remove(vicevært);
            await _db.SaveChangesAsync();
        }

        async Task<Domain.Entities.Vicevært> IViceværtRepository.GetViceværtAsync(int Id)
        {
            return await _db.Vicevært.FindAsync(Id) ?? throw new Exception("Vicevært findes ikke");
        }

        async Task IViceværtRepository.SaveViceværtAsync(Domain.Entities.Vicevært vicevært)
        {
            _db.Vicevært.Update(vicevært);
            await _db.SaveChangesAsync();
        }
    }
}
