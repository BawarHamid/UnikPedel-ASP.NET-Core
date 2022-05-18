using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.TidRegistreringContract.TidRegistreringDto;

namespace UnikPedel.Application.TidRegistreringContract
{
    public interface ITidRegistreringQuery
    {

        Task<TidRegistreringQueryDto?> GetTidRegistreringAsync(int id);
        Task<IEnumerable<TidRegistreringQueryDto>> GetTidRegistreringAsync();
    }
}
