using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.EjendomContract;
using UnikPedel.Application.EjendomContract.EjendomDto;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.Querys
{
    public class EjendomQuery : IEjendomQuery
    {

        private readonly UnikPedelContext _unikPedelContext;
        public EjendomQuery(UnikPedelContext unikPedelContext)
        {
            _unikPedelContext = unikPedelContext;
        }
         async Task<EjendomQueryDto?> IEjendomQuery.GetEjendom(Guid id)
        {
            var dbEjendom = await _unikPedelContext.Ejendom.FindAsync(id);
            if (dbEjendom is null) return new EjendomQueryDto();

            return new EjendomQueryDto
            {
                Id = dbEjendom.Id,
                VejNavn = dbEjendom.VejNavn,
                BygningsNummer = dbEjendom.BygningsNummer,
                PostNummer = dbEjendom.PostNummer,
                By = dbEjendom.By,
                Region = dbEjendom.Region,
                LandKode = dbEjendom.LandKode
            };   
        }

        async Task<IEnumerable<EjendomQueryDto>> IEjendomQuery.GetEjendoms()
        {
            var result = new List<EjendomQueryDto>();
            var dbEjendom = await _unikPedelContext.Ejendom.ToListAsync();
            dbEjendom.ForEach(a => result.Add(new EjendomQueryDto
            {
                Id = a.Id,
                VejNavn = a.VejNavn,
                BygningsNummer = a.BygningsNummer,
                PostNummer = a.PostNummer,
                By = a.By,
                Region = a.Region,
                LandKode = a.LandKode
            }));
            return result;
        }
    }
}
