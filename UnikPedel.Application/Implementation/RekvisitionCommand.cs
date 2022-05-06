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
        public readonly IRekvisitionRepository _repository;
        public RekvisitionCommand(IRekvisitionRepository repository)
        {
                _repository = repository;
        }
        public async Task CreateAsync(RekvisitionCommandDto rekvisitionDto)
        {
            var rekvisition = new Domain.Entities.Rekvisition(rekvisitionDto.Type, rekvisitionDto.Status, rekvisitionDto.Beskrivelse, rekvisitionDto.Vicevært, rekvisitionDto.Lejer, rekvisitionDto.Ejendom);
            await _repository.AddAsync(rekvisition);
        }   

        public async Task DeleteAsync(RekvisitionCommandDto rekvisitionDto)
        {
            await _repository.DeleteAsync(rekvisitionDto.Id);
        }

        public async  Task EditAsync(RekvisitionCommandDto rekvisitionDto)
        {
            var rekvisition = await _repository.GetAsync(rekvisitionDto.Id);
          
            rekvisition.Update(rekvisitionDto.Type, rekvisitionDto.Status, rekvisitionDto.Beskrivelse, rekvisitionDto.Vicevært, rekvisitionDto.Lejer, rekvisitionDto.Ejendom);

            await _repository.SaveAsync(rekvisition);
        }
    }
}
