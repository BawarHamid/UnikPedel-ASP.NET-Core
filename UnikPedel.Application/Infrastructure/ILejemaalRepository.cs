using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application.Infrastructure
{
    public interface ILejemaalRepository
    {
        Task AddAsync(Domain.Entities.Lejemaal lejemaal);
        Task<Domain.Entities.Lejemaal> GetAsync(int id);
        Task SaveAsync(Domain.Entities.Lejemaal lejemaal);
        Task DeleteAsync(int id);
    }
}
