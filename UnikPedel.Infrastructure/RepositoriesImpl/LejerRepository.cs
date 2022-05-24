using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Infrastructure;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.RepositoriesImpl
{
    public class LejerRepository : ILejerRepository
    {
        private readonly UnikPedelContext _db;

        public LejerRepository(UnikPedelContext db)
        {
            _db = db;
        }

        async Task ILejerRepository.AddLejerAsync(Domain.Entities.Lejer lejer)
        {
            _db.Add(lejer);
            await _db.SaveChangesAsync();
        }

        async Task ILejerRepository.DeleteLejerAsync(int Id)
        {
            var lejer = _db.Lejer.Find(Id);
            if (lejer is null) return;

            _db.Lejer.Remove(lejer);
            await _db.SaveChangesAsync();
        }

        async Task<Domain.Entities.Lejer> ILejerRepository.GetLejerAsync(int Id)
        {
            return await _db.Lejer.FindAsync(Id) ?? throw new Exception("Lejeren findes ikke");
        }

        async Task ILejerRepository.SaveLejerAsync(Domain.Entities.Lejer lejer)
        {
            _db.Lejer.Update(lejer);
            await _db.SaveChangesAsync();
        }
    }
}
