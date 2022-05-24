using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.LejemålContract.Dto;

namespace UnikPedel.Application.LejemålContract
{
    public interface ILejemålCommand
    {
        Task CreateAsync(LejemålCommandDto lejemålDto);
        Task EditAsync(LejemålCommandDto lejemålDto);
        Task DeleteAsync(LejemålCommandDto lejemålDto);
    }
}
