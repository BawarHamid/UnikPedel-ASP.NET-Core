using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos;

namespace UnikPedel.Contract.IServiceTidRegistrering
{
    public interface IServiceTidRegistrering
    {
        Task CreateTidRegistreringAsync(TidRegistreringDto tidRegistrering);
        Task EditTidRegistreringAsync(TidRegistreringDto tidRegistrering);
        Task DeleteTidRegistreringAsync(Guid id);
        Task<TidRegistreringDto?> GetTidRegistreringAsync(Guid Id);
        Task<IEnumerable<TidRegistreringDto>> GetTidRegistreringAsync();
    }
}
