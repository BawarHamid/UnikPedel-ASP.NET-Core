using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceEjendom.EjendomDtos;

namespace UnikPedel.Contract.IServiceEjendom
{
   public  interface IServiceEjendom
    {
        Task<EjendomDto?> GetEjendomAsync(Guid Id);
        Task<IEnumerable<EjendomDto>> GetEjendomAsync();
    }
}
