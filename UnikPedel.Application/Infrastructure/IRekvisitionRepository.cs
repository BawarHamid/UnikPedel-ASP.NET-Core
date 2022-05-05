using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application.RekvisitionIfrastructure
{
    public interface IRekvisitionRepository
    {
        Task AddAsync(Domain.Entities.Rekvisition rekvisition);
        Task<Domain.Entities.Rekvisition> GetAsync(Guid id);
        Task SaveAsync(Domain.Entities.Rekvisition rekvisition);
        Task DeleteAsync(Guid id);
    }
}
