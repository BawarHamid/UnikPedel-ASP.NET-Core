using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.TidRegistreringContract.TidRegistreringDto;

namespace UnikPedel.Application.TidRegistreringContract
{
    public interface ITidRegistreringCommand
    {
        Task CreateTidRegistreringAsyc(TidRegistreringCommandDto tidRegistreringDto);
        Task EditRegistreringAsync(TidRegistreringCommandDto tidRegistreringDto);
        Task DeleteRegistreringAsync(TidRegistreringCommandDto tidRegistreringDto);
    }
}
