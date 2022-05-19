using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application
{
    public interface IRekvisitionQuery
    {
        Task<RekvisitionQueryDto?> GetRekvisitionAsync(int id);
        Task<IEnumerable<RekvisitionQueryDto>> GetRekvisitionerAsync();
    }
}
