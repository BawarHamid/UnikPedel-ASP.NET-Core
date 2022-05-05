using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.EjendomsAnsvarligContract;
using UnikPedel.Application.EjendomsAnsvarligContract.EjendomsAnsvarligDto;
using UnikPedel.Application.Infrastructure;

namespace UnikPedel.Application.Implementation
{
    public class EjendomAnsvarligCommand : IEjendomsAnsvarligCommand
    {
        public readonly IEjendomAnsvarligRepository _repository;
        public EjendomAnsvarligCommand(IEjendomAnsvarligRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateAsync(EjendomsAnsvarligCommandDto ejendomsAnsvarlignDto)
        {
            var ejendomAnsvarlig = new Domain.Entities.EjendomsAnsvarlig(ejendomsAnsvarlignDto.Vicevært, ejendomsAnsvarlignDto.Ejendom);
            await _repository.AddAsync(ejendomAnsvarlig);
        }

        public async  Task DeleteAsync(EjendomsAnsvarligCommandDto ejendomsAnsvarlignDto)
        {
            await _repository.DeleteAsync(ejendomsAnsvarlignDto.Id);
        }

        public async Task EditAsync(EjendomsAnsvarligCommandDto ejendomsAnsvarlignDto)
        {
            var rekvisition = await _repository.GetAsync(ejendomsAnsvarlignDto.Id);

            rekvisition.Update(ejendomsAnsvarlignDto.Vicevært, ejendomsAnsvarlignDto.Ejendom); ;

            await _repository.SaveAsync(rekvisition);
        }
    }
}
