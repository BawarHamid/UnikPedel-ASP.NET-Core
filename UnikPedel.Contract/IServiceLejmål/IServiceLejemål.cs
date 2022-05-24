using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceLejmål.LejemålDtos;

namespace UnikPedel.Contract.IServiceLejmål
{
    public interface IServiceLejemål
    {
        Task CreateLejemålAsync(LejemålCreateDto lejemål);
        Task EditLejemålAsync(LejemålDto lejemål);
        Task DeleteLejemålAsync(int Id);
        Task<LejemålDto?> GetLejemålAsync(int Id);
        Task<IEnumerable<LejemålDto>> GetLejemålAsync();
    }
}
