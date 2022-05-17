using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Contract.ViceværtDtos;

namespace UnikPedel.Contract.IServiceVicevært
{
    public interface IViceværtService
    {
        Task<ViceværtCommandDto> CreateViceværtAsync(ViceværtCreateCommandDto vicevært);
        Task EditViceværtAsync(ViceværtDto vicevært);
        Task DeleteViceværtAsync(int Id);
        Task <ViceværtDto?> GetViceværtAsync(int Id);
        Task<IEnumerable<ViceværtQueryDto>> GetViceværterAsync();
    }
}
