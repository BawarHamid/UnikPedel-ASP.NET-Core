using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.LejerContract.Dtos;

namespace UnikPedel.Application.LejerContract
{
    public interface ILejerCommand
    {
        Task CreateLejerAsync(LejerCreateCommandDto lejerDto);
        Task EditLejerAsync(LejerCommandDto lejerDto);
        Task DeleteLejerAsync(LejerCommandDto lejerDto);
    }
}
