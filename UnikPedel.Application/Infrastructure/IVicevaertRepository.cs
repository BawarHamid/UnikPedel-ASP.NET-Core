using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application.Infrastructure
{
    public interface IVicevaertRepository
    {
        Task AddVicevaertAsync(Domain.Entities.Vicevaert vicevaert);
        Task DeleteVicevaertAsync(int Id);
        Task SaveVicevaertAsync(Domain.Entities.Vicevaert vicevaert);
        Task<Domain.Entities.Vicevaert> GetVicevaertAsync(int Id);
    }
}
