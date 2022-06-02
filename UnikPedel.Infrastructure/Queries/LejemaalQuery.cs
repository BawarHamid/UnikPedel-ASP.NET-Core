using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.LejemaalContract;
using UnikPedel.Application.LejemaalContract.Dto;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.Queries
{
    public class LejemaalQuery : ILejemaalQuery
    {
        private readonly UnikPedelContext _db;
        public LejemaalQuery(UnikPedelContext db)
        {
            _db = db;
        }
        public async Task<LejemaalQueryDto?> GetLejemaalAsync(int id)
        {
            var result = await _db.Lejemaal.FindAsync(id);
            if (result is null) return new LejemaalQueryDto();

            return new LejemaalQueryDto
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

        public async Task<IEnumerable<LejemaalQueryDto>> GetLejemaalAsync()
        {
            var result = new List<LejemaalQueryDto>();
            var dbLejemaal = await _db.Lejemaal.ToListAsync();
            dbLejemaal.ForEach(a => result.Add(new LejemaalQueryDto
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
