using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.LejerContract.Dtos;

namespace UnikPedel.Application.LejerContract
{
    public interface ILejerQuery
    {
        Task<LejerQueryDto?> GetLejerAsync(int Id);
        Task<IEnumerable<LejerQueryDto>> GetAllLejereAsync();
    }
}
