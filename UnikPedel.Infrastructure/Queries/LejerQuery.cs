using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.LejerContract;
using UnikPedel.Application.LejerContract.Dtos;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.Queries
{
    public class LejerQuery : ILejerQuery
    {
        private readonly UnikPedelContext _db;

        public LejerQuery(UnikPedelContext db)
        {
            _db = db;
        }

        async Task<LejerQueryDto?> ILejerQuery.GetLejerAsync(int Id)
        {
            var result = await _db.Lejer.FindAsync(Id);
            if (result is null) return new LejerQueryDto();

            return new LejerQueryDto
            {
                Id = result.Id,
                ForNavn = result.ForNavn,
                MellemNavn = result.MellemNavn,
                EfterNavn = result.EfterNavn,
                Email = result.Email,
                Telefon = result.Telefon,
                IndDato = result.IndDato,
                UdDato = result.UdDato,
                LejemålId = result.LejemålId
            };
        }

        async Task<IEnumerable<LejerQueryDto>> ILejerQuery.GetAllLejereAsync()
        {
            var result = new List<LejerQueryDto>();
            var dbLejer = await _db.Lejer.ToListAsync();
            dbLejer.ForEach(Lejer => result.Add(new LejerQueryDto
            {
                Id = Lejer.Id,
                ForNavn = Lejer.ForNavn,
                MellemNavn = Lejer.MellemNavn,
                EfterNavn = Lejer.EfterNavn,
                Email = Lejer.Email,
                Telefon = Lejer.Telefon,
                IndDato = Lejer.IndDato,
                UdDato = Lejer.UdDato,
                LejemålId = Lejer.LejemålId
            }));
            return result;
        }

       
    }
}
