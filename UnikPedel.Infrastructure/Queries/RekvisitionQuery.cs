using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.Querries
{
    public class RekvisitionQuery : IRekvisitionQuery
    {
        private readonly UnikPedelContext _db;
        public RekvisitionQuery(UnikPedelContext db)
        {
            _db = db;
        }
        public async Task<RekvisitionQueryDto?> GetRekvisitionAsync(int id)
        {
            var result = await _db.Rekvisition.FindAsync(id);
            if (result is null) return new RekvisitionQueryDto();

            return new RekvisitionQueryDto
            {
                Id = result.Id,
                Type = result.Type,
                TimeCreated = result.TimeCreated, 
                Beskrivelse = result.Beskrivelse,
                Status = result.Status, 
               VicevaertId=result.VicevaertId,
               LejerId= result.LejerId,
               EjendomId=result.EjendomId,
            };
        }

        public async Task<IEnumerable<RekvisitionQueryDto>> GetRekvisitionerAsync()
        {
            var result = new List<RekvisitionQueryDto>();
            var dbRekvisition = await _db.Rekvisition.ToListAsync();
            dbRekvisition.ForEach(a => result.Add(new RekvisitionQueryDto
            {
                Id=a.Id,    
                Type = a.Type,
                TimeCreated=a.TimeCreated,
                Beskrivelse = a.Beskrivelse,
                Status = a.Status,
                VicevaertId = a.VicevaertId,
                LejerId = a.LejerId,
                EjendomId = a.EjendomId
            }));
            return result;
        }
    }
}
