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
    public class LejemaalRepository : ILejemaalRepository
    {
        private readonly UnikPedelContext _db;
        public LejemaalRepository(UnikPedelContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Lejemaal lejemaal)
        {
            _db.Lejemaal.Add(lejemaal);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lejemaal = _db.Lejemaal.Find(id);
            if (lejemaal is null) return;

            _db.Lejemaal.Remove(lejemaal);
            await _db.SaveChangesAsync();
        }

        public async Task<Lejemaal> GetAsync(int id)
        {
            return await _db.Lejemaal.FindAsync(id) ?? throw new Exception("Lejemål not found");

        }

        public async Task SaveAsync(Lejemaal lejemaal)
        {
            _db.Lejemaal.Update(lejemaal);
            await _db.SaveChangesAsync();
        }
    }
}
