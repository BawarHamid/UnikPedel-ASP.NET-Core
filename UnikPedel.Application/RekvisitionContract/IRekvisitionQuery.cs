using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application
{
    public interface IRekvisitionQuery
    {
        Task<RekvisitionQueryDto?> GetRekvisitionAsync(Guid id);
        Task<IEnumerable<RekvisitionQueryDto>> GetRekvisitionerAsync();
    }
}
