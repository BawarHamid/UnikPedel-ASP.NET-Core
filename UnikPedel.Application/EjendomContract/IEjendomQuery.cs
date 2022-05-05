using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.EjendomContract.EjendomDto;

namespace UnikPedel.Application.EjendomContract
{
    public interface IEjendomQuery
    {
        Task<EjendomQueryDto?> GetEjendom(Guid id);
        Task<IEnumerable<EjendomQueryDto>> GetEjendoms();
    }
}
