using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;

namespace UnikPedel.Contract.IServiceRekvisition
{
    public interface IServiceRekvisition
    {
        Task CreateRekvisitionAsync(RekvisitionDto rekvisition);
        Task EditRekvisitionAsync(RekvisitionDto rekvisition);
        Task DeleteRekvisitionAsync(RekvisitionDto rekvisition);
        Task<RekvisitionDto?> GetRekvisitionAsync(Guid Id);
        Task<IEnumerable<RekvisitionDto>> GetRekvisitionAsync();
    }
}
