using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.LejemaalContract.Dto;

namespace UnikPedel.Application.LejemaalContract
{
    public interface ILejemaalQuery
    {
        Task<LejemaalQueryDto?> GetLejemaalAsync(int id);
        Task<IEnumerable<LejemaalQueryDto>> GetLejemaalAsync();
    }
}
