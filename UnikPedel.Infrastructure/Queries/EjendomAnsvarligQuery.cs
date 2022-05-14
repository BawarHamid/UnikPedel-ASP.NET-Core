using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.EjendomsAnsvarligContract;
using UnikPedel.Application.EjendomsAnsvarligContract.EjendomsAnsvarligDto;
using UnikPedel.Infrastructure.Database;

namespace UnikPedel.Infrastructure.Queries
{
    public class EjendomAnsvarligQuery : IEjendomsAnsvarligQuery

    {
        private readonly UnikPedelContext _unikPedelContext;
        public EjendomAnsvarligQuery(UnikPedelContext unikPedelContext)
        {
            _unikPedelContext = unikPedelContext;
        }
     

       async  Task<EjendomsAnsvarligQueryDto?> IEjendomsAnsvarligQuery.GetEjendomAnsvarligAsync(Guid id)
        {
            var dbEjendomAnsvarlig = await _unikPedelContext.EjendomsAnsvarlig.FindAsync(id);
            if (dbEjendomAnsvarlig is null) return new EjendomsAnsvarligQueryDto();

            return new EjendomsAnsvarligQueryDto
            {
                ViceværtId = dbEjendomAnsvarlig.ViceværtId,
                Vicevært = dbEjendomAnsvarlig.Vicevært,
                EjendomId = dbEjendomAnsvarlig.EjendomId,
                Ejendom= dbEjendomAnsvarlig.Ejendom
            };
        }

       

        async Task<IEnumerable<EjendomsAnsvarligQueryDto>> IEjendomsAnsvarligQuery.GetEjendomsAnsvarligAsync()
        {
            var result = new List<EjendomsAnsvarligQueryDto>();
            var dbEjendomAnsvarlig = await _unikPedelContext.EjendomsAnsvarlig.ToListAsync();
            dbEjendomAnsvarlig.ForEach(a => result.Add(new EjendomsAnsvarligQueryDto
            {
                ViceværtId = a.ViceværtId,
                Vicevært = a.Vicevært,
                EjendomId = a.EjendomId,
                Ejendom = a.Ejendom

            }));
            return result;
        }
    }
}
