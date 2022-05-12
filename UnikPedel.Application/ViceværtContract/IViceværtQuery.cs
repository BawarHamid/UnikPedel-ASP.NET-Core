using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Contract.Dtos;

namespace UnikPedel.Application.Contract.ViceværtInterface
{
    public interface IViceværtQuery
    {   
        Task<ViceværtQueryDto?> GetViceværtAsync(Guid Id);
        Task<IEnumerable<ViceværtQueryDto>> GetAllViceværterAsync();
    }
}
