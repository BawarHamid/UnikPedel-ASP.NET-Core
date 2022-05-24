using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceLejer.LejerDtos;

namespace UnikPedel.Contract.IServiceLejer
{
    public interface ILejerService
    {
        Task CreateLejerAsync(LejerCreateDto lejer);
        Task EditLejerAsync(LejerDto lejer);
        Task DeleteLejerAsync(int Id);
        Task<LejerDto?> GetLejerAsync(int Id);
        Task<IEnumerable<LejerDto>> GetLejereAsync();
    }
}
