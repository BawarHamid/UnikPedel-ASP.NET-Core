using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Contract.Dtos;

namespace UnikPedel.Application.Contract.ViceværtInterface
{
    public interface IViceværtCommand
    {
        Task<ViceværtCommandDto> CreateViceværtAsyc(ViceværtCreateCommandDto viceværtDto);
        Task EditViceværtAsync(ViceværtCommandDto viceværtDto);
        Task DeleteViceværtAsync(ViceværtCommandDto viceværtDto);
    }
}
