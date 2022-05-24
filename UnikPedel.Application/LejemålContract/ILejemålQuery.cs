using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.LejemålContract.Dto;

namespace UnikPedel.Application.LejemålContract
{
    public interface ILejemålQuery
    {
        Task<LejemålQueryDto?> GetLejemålAsync(int id);
        Task<IEnumerable<LejemålQueryDto>> GetLejemålAsync();
    }
}
