using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.ViceværtDtos;

namespace UnikPedel.Contract.IServiceVicevært
{
    public interface IViceværtService
    {
        Task CreateViceværtAsync(ViceværtDto vicevært);
        Task EditViceværtAsync(ViceværtDto vicevært);
        Task DeleteViceværtAsync(ViceværtDto vicevært);
        Task <ViceværtDto?> GetViceværtAsync(Guid Id);
        Task<IEnumerable<ViceværtDto>> GetViceværterAsync();
    }
}
