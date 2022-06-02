using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Infrastructure;
using UnikPedel.Application.LejemaalContract;
using UnikPedel.Application.LejemaalContract.Dto;
using UnikPedel.Domain.Entities;

namespace UnikPedel.Application.Implementation
{
    public class LejemaalCommand : ILejemaalCommand
    {
        private readonly ILejemaalRepository _repository;
        private readonly IMapper _mapper;

        public LejemaalCommand(ILejemaalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task ILejemaalCommand.CreateAsync(LejemaalCommandDto lejemaalDto)
        {
            var lejemaal = new Lejemaal(lejemaalDto.VejNavn, lejemaalDto.BygningsNummer, lejemaalDto.AndenAdresse, lejemaalDto.PostNummer, lejemaalDto.City, lejemaalDto.Region, lejemaalDto.LandKode, lejemaalDto.IsBookable, lejemaalDto.EjendomId);
            await _repository.AddAsync(lejemaal);

        }

        public async Task DeleteAsync(LejemaalCommandDto lejemaalDto)
        {
            await _repository.DeleteAsync(lejemaalDto.Id);
        }

        public async Task EditAsync(LejemaalCommandDto lejemaalDto)
        {
            var lejemaal = await _repository.GetAsync(lejemaalDto.Id);

            lejemaal.Update(lejemaalDto.VejNavn, lejemaalDto.BygningsNummer, lejemaalDto.AndenAdresse, lejemaalDto.PostNummer, lejemaalDto.City, lejemaalDto.Region, lejemaalDto.LandKode, lejemaalDto.IsBookable, lejemaalDto.EjendomId);

            await _repository.SaveAsync(lejemaal);
        }

    }
}
