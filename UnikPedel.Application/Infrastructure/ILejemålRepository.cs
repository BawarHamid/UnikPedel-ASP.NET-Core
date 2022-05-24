using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application.Infrastructure
{
    public interface ILejemålRepository
    {
        Task AddAsync(Domain.Entities.Lejemål lejemål);
        Task<Domain.Entities.Lejemål> GetAsync(int id);
        Task SaveAsync(Domain.Entities.Lejemål lejemål);
        Task DeleteAsync(int id);
    }
}
