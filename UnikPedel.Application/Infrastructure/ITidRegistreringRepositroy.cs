using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application.Infrastructure
{
    public interface ITidRegistreringRepositroy
    {
        Task AddRegistreringAsync(Domain.Entities.TidRegistering tidRegistering);
        Task<Domain.Entities.TidRegistering> GetTidRegistreringAsync(int id);
        Task SaveTidRegistreringAsync(Domain.Entities.TidRegistering tidRegistering);
        Task DeleteTidRegistreringAsync(int id);
    }
}
