using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.LejemålContract;
using UnikPedel.Application.LejemålContract.Dto;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.Queries
{
    public class LejemålQuery : ILejemålQuery
    {
        private readonly UnikPedelContext _db;
        public LejemålQuery(UnikPedelContext db)
        {
            _db = db;
        }
        public async Task<LejemålQueryDto?> GetLejemålAsync(int id)
        {
            var result = await _db.Lejemål.FindAsync(id);
            if (result is null) return new LejemålQueryDto();

            return new LejemålQueryDto
            {
                Id = result.Id,
                VejNavn = result.VejNavn,
                BygningNummer = result.BygningsNummer,
                AndenAdresse = result.AndenAdresse,
                PostNummer = result.PostNummer,
                City = result.City,
                Region = result.Region,
                LandKode = result.LandKode,
                IsBookable = result.IsBookable,
                EjendomId = result.EjendomId,
                
            };
        }

        public async Task<IEnumerable<LejemålQueryDto>> GetLejemålAsync()
        {
            var result = new List<LejemålQueryDto>();
            var dbLejemål = await _db.Lejemål.ToListAsync();
            dbLejemål.ForEach(a => result.Add(new LejemålQueryDto
            {
                Id = a.Id,
                VejNavn = a.VejNavn,
                BygningNummer = a.BygningsNummer,
                AndenAdresse = a.AndenAdresse,
                PostNummer = a.PostNummer,
                City = a.City,
                Region = a.Region,
                LandKode = a.LandKode,
                IsBookable = a.IsBookable,
                EjendomId = a.EjendomId,

            }));
            return result;
        }
    }
}
