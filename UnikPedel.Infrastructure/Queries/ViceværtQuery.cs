using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Application.Contract.ViceværtInterface;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.Queries
{
    public class ViceværtQuery : IViceværtQuery
    {
        private readonly UnikPedelContext _db;

        public ViceværtQuery(UnikPedelContext db)
        {
            _db = db;
        }

        async Task<ViceværtQueryDto?> IViceværtQuery.GetViceværtAsync(Guid Id)
        {
            var result = await _db.Vicevært.FindAsync(Id);
            if (result is null) return new ViceværtQueryDto();

            return new ViceværtQueryDto
            {
                Id = result.Id,
                ForNavn = result.ForNavn,
                EfterNavn = result.EfterNavn,
                Telefon = result.Telefon,
                Email = result.Email
            };
        }

        async Task<IEnumerable<ViceværtQueryDto>> IViceværtQuery.GetAllViceværter()
        {
            var result = new List<ViceværtQueryDto>();
            var dbViceværter = await _db.Vicevært.ToListAsync();
            dbViceværter.ForEach(vicevært => result.Add(new ViceværtQueryDto
            {
                Id = vicevært.Id,
                ForNavn = vicevært.ForNavn,
                EfterNavn = vicevært.EfterNavn,
                Telefon = vicevært.Telefon,
                Email = vicevært.Email
            }));
            return result;
        }
    }
}
