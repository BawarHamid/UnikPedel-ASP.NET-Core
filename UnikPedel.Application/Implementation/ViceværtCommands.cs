using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Application.Contract.ViceværtInterface;
using UnikPedel.Application.Infrastructure;

namespace UnikPedel.Application.Implementation
{
    public class ViceværtCommands : IViceværtCommand
    {
        private readonly IViceværtRepository _repository;
        public ViceværtCommands(IViceværtRepository repository)
        {
            _repository = repository;
        }

        async Task IViceværtCommand.CreateViceværtAsyc(ViceværtCommandDto viceværtDto)
        {
            var vicevært = new UnikPedel.Domain.Entities.Vicevært(viceværtDto.ForNavn, viceværtDto.EfterNavn, viceværtDto.Telefon, viceværtDto.Email);
            await _repository.AddViceværtAsync(vicevært);
        }

        async Task IViceværtCommand.DeleteViceværtAsync(ViceværtCommandDto viceværtDto)
        {
            await _repository.DeleteViceværtAsync(viceværtDto.Id);
        }

        async Task IViceværtCommand.EditViceværtAsync(ViceværtCommandDto viceværtDto)
        {
            var vicevært = await _repository.GetViceværtAsync(viceværtDto.Id);
            vicevært.Update(viceværtDto.ForNavn, viceværtDto.EfterNavn, viceværtDto.Telefon, viceværtDto.Email); 
            await _repository.SaveViceværtAsync(vicevært);
        }
    }
}
