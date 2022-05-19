using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Application
{
    public interface IRekvisitionCommand
    {
        Task CreateAsync(RekvisitionCommandDto rekvisitionDto);
        Task EditAsync(RekvisitionCommandDto rekvisitionDto);
        Task DeleteAsync(RekvisitionCommandDto rekvisitionDto);
    }
}
