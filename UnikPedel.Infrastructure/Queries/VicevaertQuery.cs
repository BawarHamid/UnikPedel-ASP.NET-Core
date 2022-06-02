using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Application.Contract.VicevaertInterface;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.Queries
{
    public class VicevaertQuery : IVicevaertQuery
    {
        private readonly UnikPedelContext _db;

        public VicevaertQuery(UnikPedelContext db)
        {
            _db = db;
        }

        async Task<VicevaertQueryDto?> IVicevaertQuery.GetVicevaertAsync(int Id)
        {
            var result = await _db.Vicevaert.FindAsync(Id);
            if (result is null) return new VicevaertQueryDto();

            return new VicevaertQueryDto
            {
                Id = result.Id,
                ForNavn = result.ForNavn,
                EfterNavn = result.EfterNavn,
                Telefon = result.Telefon,
                Email = result.Email
            };
        }

        async Task<IEnumerable<VicevaertQueryDto>> IVicevaertQuery.GetAllVicevaerterAsync()
        {
            var result = new List<VicevaertQueryDto>();
            var dbVicevaerter = await _db.Vicevaert.ToListAsync();
            dbVicevaerter.ForEach(vicevaert => result.Add(new VicevaertQueryDto
            {
                Id = vicevaert.Id,
                ForNavn = vicevaert.ForNavn,
                EfterNavn = vicevaert.EfterNavn,
                Telefon = vicevaert.Telefon,
                Email = vicevaert.Email
            }));
            return result;
        }
    }
}
