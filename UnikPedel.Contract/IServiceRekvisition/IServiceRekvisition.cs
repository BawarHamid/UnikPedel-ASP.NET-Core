using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;

namespace UnikPedel.Contract.IServiceRekvisition
{
    public interface IServiceRekvisition
    {
        Task CreateRekvisitionAsync(RekvisitionCreateCommandDto rekvisition);
        Task EditRekvisitionAsync(RekvisitionDto rekvisition);
        Task DeleteRekvisitionAsync(int Id);
        Task<RekvisitionDto?> GetRekvisitionAsync(int Id);
        Task<IEnumerable<RekvisitionDto>> GetRekvisitionerAsync();
    }
}
