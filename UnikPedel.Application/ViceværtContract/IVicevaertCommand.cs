using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Contract.Dtos;

namespace UnikPedel.Application.Contract.VicevaertInterface
{
    public interface IVicevaertCommand
    {
        Task CreateVicevaertAsyc(VicevaertCreateCommandDto vicevaertDto);
        Task EditVicevaertAsync(VicevaertCommandDto vicevaertDto);
        Task DeleteVicevaertAsync(VicevaertCommandDto vicevaertDto);
    }
}
