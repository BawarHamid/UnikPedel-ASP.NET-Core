using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application.Infrastructure
{
    public interface ILejerRepository
    {
        Task AddLejerAsync(Domain.Entities.Lejer lejer);
        Task DeleteLejerAsync(int Id);
        Task SaveLejerAsync(Domain.Entities.Lejer lejer);
        Task<Domain.Entities.Lejer> GetLejerAsync(int Id);
    }
}
