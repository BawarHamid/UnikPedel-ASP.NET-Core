using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Infrastructure;
using UnikPedel.Application.LejemålContract;
using UnikPedel.Application.LejemålContract.Dto;
using UnikPedel.Domain.Entities;

namespace UnikPedel.Application.Implementation
{
    public class LejemålCommand : ILejemålCommand
    {
        private readonly ILejemålRepository _repository;
        private readonly IMapper _mapper;

        public LejemålCommand(ILejemålRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task ILejemålCommand.CreateAsync(LejemålCommandDto lejemålDto)
        {
            var lejemål = new Lejemål(lejemålDto.VejNavn, lejemålDto.BygningsNummer, lejemålDto.AndenAdresse, lejemålDto.PostNummer, lejemålDto.City, lejemålDto.Region, lejemålDto.LandKode, lejemålDto.IsBookable, lejemålDto.EjendomId);
            await _repository.AddAsync(lejemål);

        }

        public async Task DeleteAsync(LejemålCommandDto lejemålDto)
        {
            await _repository.DeleteAsync(lejemålDto.Id);
        }

        public async Task EditAsync(LejemålCommandDto lejemålDto)
        {
            var lejemål = await _repository.GetAsync(lejemålDto.Id);

            lejemål.Update(lejemålDto.VejNavn, lejemålDto.BygningsNummer, lejemålDto.AndenAdresse, lejemålDto.PostNummer, lejemålDto.City, lejemålDto.Region, lejemålDto.LandKode, lejemålDto.IsBookable, lejemålDto.EjendomId);

            await _repository.SaveAsync(lejemål);
        }

    }
}
