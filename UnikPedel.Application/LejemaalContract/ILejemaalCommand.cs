using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.LejemaalContract.Dto;

namespace UnikPedel.Application.LejemaalContract
{
    public interface ILejemaalCommand
    {
        Task CreateAsync(LejemaalCommandDto lejemaalDto);
        Task EditAsync(LejemaalCommandDto lejemaalDto);
        Task DeleteAsync(LejemaalCommandDto lejemaalDto);
    }
}
