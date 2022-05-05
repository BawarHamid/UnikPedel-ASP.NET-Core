using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.RekvisitionIfrastructure;
using UnikPedel.Domain.Entities;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.RepositoriesImpl
{
    public class RekvisitionRepository : IRekvisitionRepository
    {
        private readonly UnikPedelContext _db;
        public RekvisitionRepository(UnikPedelContext db)
        {
            _db = db;
        }
        public  async Task AddAsync(Rekvisition rekvisition)
        {
            _db.Rekvisition.Add(rekvisition);
            await _db.SaveChangesAsync();
        }

        public async  Task DeleteAsync(Guid id)
        {
            var rekvisition = _db.Rekvisition.Find(id);
            if (rekvisition is null) return;

            _db.Rekvisition.Remove(rekvisition);
            await _db.SaveChangesAsync();
        }

        public async Task<Rekvisition> GetAsync(Guid id)
        {
            return await _db.Rekvisition.FindAsync(id) ?? throw new Exception("Rekvisition not found");
        }

        public async Task SaveAsync(Rekvisition rekvisition)
        {
            _db.Rekvisition.Update(rekvisition);
            await _db.SaveChangesAsync();
        }
    }
}
