using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceLejmaal.LejemaalDtos;

namespace UnikPedel.Contract.IServiceLejmaal
{
    public interface IServiceLejemaal
    {
        Task CreateLejemaalAsync(LejemaalCreateDto lejemaal);
        Task EditLejemaalAsync(LejemaalDto lejemaal);
        Task DeleteLejemaalAsync(int Id);
        Task<LejemaalDto?> GetLejemaalAsync(int Id);
        Task<IEnumerable<LejemaalDto>> GetLejemaalAsync();
    }
}
