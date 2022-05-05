using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Infrastructure;
using UnikPedel.Domain.Entities;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.RepositoriesImpl
{
    public class EjendomAnsavrligRepository: IEjendomAnsvarligRepository
    {
        private readonly UnikPedelContext _db;
        public EjendomAnsavrligRepository(UnikPedelContext db)
        {
            _db = db;
        }

        public async Task AddAsync(EjendomsAnsvarlig ejendomsAnsvarlig)
        {
            _db.EjendomsAnsvarlig.Add(ejendomsAnsvarlig);
            await _db.SaveChangesAsync();
        }

        public async  Task DeleteAsync(Guid id)
        {
            var ejendomAnsvarlig = _db.EjendomsAnsvarlig.Find(id);
            if (ejendomAnsvarlig is null) return;

            _db.EjendomsAnsvarlig.Remove(ejendomAnsvarlig);
            await _db.SaveChangesAsync();
        }

        public  async Task<EjendomsAnsvarlig> GetAsync(Guid id)
        {
            return await _db.EjendomsAnsvarlig.FindAsync(id) ?? throw new Exception("EjendomAnsvarlig not found");
        }

        public async  Task SaveAsync(EjendomsAnsvarlig ejendomAnsvarlig)
        {
            _db.EjendomsAnsvarlig.Update(ejendomAnsvarlig);
            await _db.SaveChangesAsync();
        }
    }
}
