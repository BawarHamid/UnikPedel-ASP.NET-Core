using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.EjendomsAnsvarligContract.EjendomsAnsvarligDto;

namespace UnikPedel.Application.EjendomsAnsvarligContract
{
    public interface IEjendomsAnsvarligQuery
    {

        Task<EjendomsAnsvarligQueryDto?> GetEjendomAnsvarligAsync(int id);
        Task<IEnumerable<EjendomsAnsvarligQueryDto>> GetEjendomsAnsvarligAsync();





    }
}
