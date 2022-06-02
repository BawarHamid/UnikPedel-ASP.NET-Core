using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Infrastructure;
using UnikPedel.Application.LejerContract;
using UnikPedel.Application.LejerContract.Dtos;

namespace UnikPedel.Application.Implementation
{
    public class LejerCommands : ILejerCommand
    {
        private readonly ILejerRepository _repository;

        public LejerCommands(ILejerRepository repository)
        {
            _repository = repository;
        }

        async Task ILejerCommand.CreateLejerAsync(LejerCreateCommandDto lejerDto)
        {
            var lejer = new Domain.Entities.Lejer(lejerDto.ForNavn, lejerDto.MellemNavn, lejerDto.EfterNavn, lejerDto.Email, lejerDto.Telefon, lejerDto.IndDato, lejerDto.UdDato, lejerDto.LejemaalId);
            await _repository.AddLejerAsync(lejer);
        }

        async Task ILejerCommand.DeleteLejerAsync(LejerCommandDto lejerDto)
        {
            await _repository.DeleteLejerAsync(lejerDto.Id);
        }

        async Task ILejerCommand.EditLejerAsync(LejerCommandDto lejerDto)
        {
            var lejer = await _repository.GetLejerAsync(lejerDto.Id);
            lejer.Update(lejerDto.ForNavn, lejerDto.MellemNavn, lejerDto.EfterNavn, lejerDto.Email, lejerDto.Telefon, lejerDto.IndDato, lejerDto.UdDato, lejerDto.LejemaalId);
            await _repository.SaveLejerAsync(lejer);
        }
    }
}
