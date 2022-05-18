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
    public class TidRegistreringRepositroy : ITidRegistreringRepositroy
    {
        private readonly UnikPedelContext _db;
        public TidRegistreringRepositroy(UnikPedelContext db)
        {
            _db = db;
        }

      
       async Task ITidRegistreringRepositroy.AddRegistreringAsync(TidRegistering tidRegistering)
        {
            _db.TidRegistrering.Add(tidRegistering);
            await _db.SaveChangesAsync();
        }

        

        async Task ITidRegistreringRepositroy.DeleteTidRegistreringAsync(int id)
        {
            var tidRegistering = _db.TidRegistrering.Find(id);
            if (tidRegistering is null) return;

            _db.TidRegistrering.Remove(tidRegistering);
            await _db.SaveChangesAsync();
        }

    

        async Task<TidRegistering> ITidRegistreringRepositroy.GetTidRegistreringAsync(int id)
        {
            return await _db.TidRegistrering.FindAsync(id) ?? throw new Exception("TidRegistrering not found");
        }

        

        async Task ITidRegistreringRepositroy.SaveTidRegistreringAsync(TidRegistering tidRegistering)
        {
            _db.TidRegistrering.Update(tidRegistering);
            await _db.SaveChangesAsync();
        }
    }
}
