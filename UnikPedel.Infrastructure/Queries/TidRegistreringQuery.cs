using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.TidRegistreringContract;
using UnikPedel.Application.TidRegistreringContract.TidRegistreringDto;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.Queries
{
    public class TidRegistreringQuery : ITidRegistreringQuery
    {
        private readonly UnikPedelContext _unikPedelContext;
        public TidRegistreringQuery(UnikPedelContext unikPedelContext)
        {
            _unikPedelContext = unikPedelContext;
        }

      async   public Task<TidRegistreringQueryDto?> GetTidRegistreringAsync(int id)
        {
            var dbTidRegistrering = await _unikPedelContext.TidRegistrering.FindAsync(id);
            if (dbTidRegistrering is null) return new TidRegistreringQueryDto();

            return new TidRegistreringQueryDto
            {
                Id= dbTidRegistrering.Id,
                RegisterDato= dbTidRegistrering.RegisterDato,
                AntalTimer= dbTidRegistrering.AntalTimer,
                VicevaertId= dbTidRegistrering.VicevaertId,
                RekvisitionId= dbTidRegistrering.RekvisitionId
            };
        }

       async  public Task<IEnumerable<TidRegistreringQueryDto>> GetTidRegistreringAsync()
        {
            var result = new List<TidRegistreringQueryDto>();
            var dbTidRegistrering = await _unikPedelContext.TidRegistrering.ToListAsync();
            dbTidRegistrering.ForEach(a => result.Add(new TidRegistreringQueryDto
            {
                Id = a.Id,
                RegisterDato = a.RegisterDato,
                AntalTimer = a.AntalTimer,
                VicevaertId = a.VicevaertId,
                RekvisitionId = a.RekvisitionId

            }));
            return result;
        }
    }
}
