using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Contract.Dtos;

namespace UnikPedel.Application.Contract.VicevaertInterface
{
    public interface IVicevaertQuery
    {   
        Task<VicevaertQueryDto?> GetVicevaertAsync(int Id);
        Task<IEnumerable<VicevaertQueryDto>> GetAllVicevaerterAsync();
    }
}
