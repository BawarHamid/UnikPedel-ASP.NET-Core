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
    public class LejemålRepository : ILejemålRepository
    {
        private readonly UnikPedelContext _db;
        public LejemålRepository(UnikPedelContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Lejemål lejemål)
        {
            _db.Lejemål.Add(lejemål);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lejemål = _db.Lejemål.Find(id);
            if (lejemål is null) return;

            _db.Lejemål.Remove(lejemål);
            await _db.SaveChangesAsync();
        }

        public async Task<Lejemål> GetAsync(int id)
        {
            return await _db.Lejemål.FindAsync(id) ?? throw new Exception("Lejemål not found");

        }

        public async Task SaveAsync(Lejemål lejemål)
        {
            _db.Lejemål.Update(lejemål);
            await _db.SaveChangesAsync();
        }
    }
}
