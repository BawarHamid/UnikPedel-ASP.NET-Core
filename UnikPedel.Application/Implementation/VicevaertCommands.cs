using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Application.Contract.VicevaertInterface;
using UnikPedel.Application.Infrastructure;

namespace UnikPedel.Application.Implementation
{
    public class VicevaertCommands : IVicevaertCommand
    {
        private readonly IVicevaertRepository _repository;
        private readonly IServiceProvider _serviceProvider;
        public VicevaertCommands(IVicevaertRepository repository, IServiceProvider serviceProvider)
        {
            _repository = repository;
            _serviceProvider = serviceProvider;
        }

        async Task IVicevaertCommand.CreateVicevaertAsyc(VicevaertCreateCommandDto vicevaertDto)
        {
            var vicevaert = new Domain.Entities.Vicevaert(_serviceProvider, vicevaertDto.ForNavn, vicevaertDto.EfterNavn, vicevaertDto.Telefon, vicevaertDto.Email);
            await _repository.AddVicevaertAsync(vicevaert);
        }

        async Task IVicevaertCommand.DeleteVicevaertAsync(VicevaertCommandDto vicevaertDto)
        {
            await _repository.DeleteVicevaertAsync(vicevaertDto.Id);
        }

        async Task IVicevaertCommand.EditVicevaertAsync(VicevaertCommandDto vicevaertDto)
        {
            var vicevaert = await _repository.GetVicevaertAsync(vicevaertDto.Id);
            vicevaert._serviceProvider = _serviceProvider;
            vicevaert.Update(vicevaertDto.ForNavn, vicevaertDto.EfterNavn, vicevaertDto.Telefon, vicevaertDto.Email);
            await _repository.SaveVicevaertAsync(vicevaert); 
        }
    }
}
