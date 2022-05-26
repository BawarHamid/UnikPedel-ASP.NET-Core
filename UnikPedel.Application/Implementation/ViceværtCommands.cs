using AutoMapper;
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
        private readonly IServiceProvider _serviceProvider;
        public ViceværtCommands(IViceværtRepository repository, IServiceProvider serviceProvider)
        {
            _repository = repository;
            _serviceProvider = serviceProvider;
        }

        async Task IViceværtCommand.CreateViceværtAsyc(ViceværtCreateCommandDto viceværtDto)
        {
            var vicevært = new Domain.Entities.Vicevært(_serviceProvider, viceværtDto.ForNavn, viceværtDto.EfterNavn, viceværtDto.Telefon, viceværtDto.Email);
            await _repository.AddViceværtAsync(vicevært);
        }

        async Task IViceværtCommand.DeleteViceværtAsync(ViceværtCommandDto viceværtDto)
        {
            await _repository.DeleteViceværtAsync(viceværtDto.Id);
        }

        async Task IViceværtCommand.EditViceværtAsync(ViceværtCommandDto viceværtDto)
        {
            var vicevært = await _repository.GetViceværtAsync(viceværtDto.Id);
            vicevært._serviceProvider = _serviceProvider;
            vicevært.Update(viceværtDto.ForNavn, viceværtDto.EfterNavn, viceværtDto.Telefon, viceværtDto.Email);
            await _repository.SaveViceværtAsync(vicevært);
        }
    }
}
