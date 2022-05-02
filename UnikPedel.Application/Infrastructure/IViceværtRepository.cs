using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application.Infrastructure
{
    public interface IViceværtRepository
    {
        Task AddViceværtAsync(Domain.Entities.Vicevært vicevært);
        Task DeleteViceværtAsync(Guid Id);
        Task SaveViceværtAsync(Domain.Entities.Vicevært vicevært);
        Task<Domain.Entities.Vicevært> GetViceværtAsync(Guid Id);
    }
}
