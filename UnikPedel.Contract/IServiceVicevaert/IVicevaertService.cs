using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Contract.VicevaertDtos;

namespace UnikPedel.Contract.IServiceVicevaert
{
    public interface IVicevaertService
    {
        Task CreateVicevaertAsync(VicevaertCreateDto vicevaert);
        Task EditVicevaertAsync(VicevaertDto vicevaert);
        Task DeleteVicevaertAsync(int Id);
        Task <VicevaertDto?> GetVicevaertAsync(int Id);
        Task<IEnumerable<VicevaertDto>> GetVicevaerterAsync();
    }
}
