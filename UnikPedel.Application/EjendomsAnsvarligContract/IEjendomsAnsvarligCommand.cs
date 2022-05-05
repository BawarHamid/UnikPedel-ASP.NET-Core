using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.EjendomsAnsvarligContract.EjendomsAnsvarligDto;

namespace UnikPedel.Application.EjendomsAnsvarligContract
{
    public interface IEjendomsAnsvarligCommand
    {
        Task CreateAsync(EjendomsAnsvarligCommandDto ejendomsAnsvarlignDto);
        Task EditAsync(EjendomsAnsvarligCommandDto ejendomsAnsvarlignDto);
        Task DeleteAsync(EjendomsAnsvarligCommandDto ejendomsAnsvarlignDto);
    }
}
