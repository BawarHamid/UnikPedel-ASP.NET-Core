using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceEjendomAnsvarlig.EjendomAnsvarligDtos;

namespace UnikPedel.Contract.IServiceEjendomAnsvarlig
{
    public interface IServiceEjendomAnsvarlig
    {
        Task CreateEjendomAnsvarligAsync(EjendomAnsvarligCreateDto ejendomAnsvarlig);
        Task EditEjendomAnsvarligAsync(EjendomAnsvarligDto ejendomAnsvarlig);
        Task DeleteEjendomAnsvarligAsync(int Id);
        Task<EjendomAnsvarligDto?> GetEjendomAnsvarligAsync(int Id);
        Task<IEnumerable<EjendomAnsvarligDto>> GetEjendomAnsvarligAsync();
    }
}
