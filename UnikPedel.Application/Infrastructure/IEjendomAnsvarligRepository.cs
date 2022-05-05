using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application.Infrastructure
{
    public interface IEjendomAnsvarligRepository
    {
        Task AddAsync(Domain.Entities.EjendomsAnsvarlig ejendomsAnsvarlig);
        Task<Domain.Entities.EjendomsAnsvarlig> GetAsync(Guid id);
        Task SaveAsync(Domain.Entities.EjendomsAnsvarlig ejendomAnsvarlig);
        Task DeleteAsync(Guid id);
    }
}
