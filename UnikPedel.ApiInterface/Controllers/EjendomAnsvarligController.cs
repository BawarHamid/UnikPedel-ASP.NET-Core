using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Application.EjendomsAnsvarligContract;
using UnikPedel.Application.EjendomsAnsvarligContract.EjendomsAnsvarligDto;
using UnikPedel.Contract.IServiceEjendomAnsvarlig;
using UnikPedel.Contract.IServiceEjendomAnsvarlig.EjendomAnsvarligDtos;

namespace UnikPedel.ApiInterface.Controllers
{
    [Route("api/EjendomAnsvarlig")]
    [ApiController]

    public class EjendomAnsvarligController : ControllerBase, IServiceEjendomAnsvarlig
    {
        private readonly IEjendomsAnsvarligQuery _ejendomAnsvarligQuery;
        private readonly IEjendomsAnsvarligCommand _ejendomAnsvarligCommand;
        private readonly IMapper _mapper;

        public EjendomAnsvarligController(IEjendomsAnsvarligQuery ejendomAnsvarligQuery, IEjendomsAnsvarligCommand ejendomAnsvarligCommand, IMapper mapper)
        {
            _ejendomAnsvarligQuery = ejendomAnsvarligQuery;
            _ejendomAnsvarligCommand = ejendomAnsvarligCommand;
            _mapper = mapper;

        }
        // POST api/<EjendomAnsvarligController> opretter en EjendomAnsvarlig.
        [HttpPost]
        public async Task CreateEjendomAnsvarligAsync(EjendomAnsvarligCreateDto ejendomAnsvarlig)
        {
           var mapperEjendom = _mapper.Map<EjendomsAnsvarligCommandDto>(ejendomAnsvarlig);
            await _ejendomAnsvarligCommand.CreateAsync(mapperEjendom);
           
        }
        
        // DELETE api/<EjendomAnsvarligController>/ sletter en bestemet EejendomAnsvarlig udfra Id
        [HttpDelete("{Id}")]
        public async Task DeleteEjendomAnsvarligAsync(int Id)
        {
            await _ejendomAnsvarligCommand.DeleteAsync(new EjendomsAnsvarligCommandDto { Id = Id });
        }

        //PUT api/<EjendomAnsvarligController>/ når man laver update på en EjendomAnsvarlig.
        [HttpPut("{Id}")]
        public async Task EditEjendomAnsvarligAsync(EjendomAnsvarligDto ejendomAnsvarlig)
        {
            var result = _mapper.Map<EjendomsAnsvarligCommandDto>(ejendomAnsvarlig);
            await _ejendomAnsvarligCommand.EditAsync(result);
            
        }


        // GET api/<EjendomController> henter en bestemt Ejendom udfra Id
        [HttpGet("{Id}")]
        public async Task<EjendomAnsvarligDto?> GetEjendomAnsvarligAsync(int Id)
        {            
            var ejendomsAnsvarlig = await _ejendomAnsvarligQuery.GetEjendomAnsvarligAsync(Id);
            if (ejendomsAnsvarlig is null) return null;
            return _mapper.Map<EjendomAnsvarligDto>(ejendomsAnsvarlig);

        }


        // GET: api/<EjendomAnsvarligController> henter en list med alle EjendomAnsvarlig
        [HttpGet]
        public async Task<IEnumerable<EjendomAnsvarligDto>> GetEjendomAnsvarligAsync()
        {
            var ejendomAnsvar = await _ejendomAnsvarligQuery.GetEjendomsAnsvarligAsync();
            if (ejendomAnsvar == null) return null;
            return _mapper.Map<IEnumerable<EjendomAnsvarligDto>>(ejendomAnsvar); 
        }
    }
}
