﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.RekvisitionIfrastructure;
using UnikPedel.Domain.Entities;

namespace UnikPedel.Application.RekvisitionImpimentation
{
    public class RekvisitionCommand : IRekvisitionCommand
    {
        private readonly IRekvisitionRepository _repository;
        private readonly IMapper _mapper;
        public RekvisitionCommand(IRekvisitionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task IRekvisitionCommand.CreateAsync(RekvisitionCreateCommandDto rekvisitionDto)
        {
            var rekvisition = new Rekvisition(rekvisitionDto.Type, rekvisitionDto.Status, rekvisitionDto.Beskrivelse, rekvisitionDto.ViceværtId, rekvisitionDto.LejerId, rekvisitionDto.EjendomsId);
            await _repository.AddAsync(rekvisition);
            _mapper.Map<RekvisitionCommandDto>(rekvisition);
            

            //var rekvisition = new Rekvisition(rekvisitionDto.Type, rekvisitionDto.Status, rekvisitionDto.Beskrivelse, rekvisitionDto.Vicevært, rekvisitionDto.Lejer, rekvisitionDto.Ejendom);
            //var rekvisition = new Rekvisition(rekvisitionDto.Beskrivelse, rekvisitionDto.Type);
            //await _repository.AddAsync(rekvisition);
        }   

        public async Task DeleteAsync(RekvisitionCommandDto rekvisitionDto)
        {
            await _repository.DeleteAsync(rekvisitionDto.Id);
        }

        public async  Task EditAsync(RekvisitionCommandDto rekvisitionDto)
        {
            var rekvisition = await _repository.GetAsync(rekvisitionDto.Id);

            //rekvisition.Update(rekvisitionDto.Type, rekvisitionDto.Status, rekvisitionDto.Beskrivelse, rekvisitionDto.Vicevært, rekvisitionDto.Lejer, rekvisitionDto.Ejendom);

            await _repository.SaveAsync(rekvisition);
        }
    }
}
