using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikPedel.Application;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;

namespace UnikPedel.ApiInterface.Controllers
{
    [Route("api/Rekvisition")]
    [ApiController]
    public class RekvisitionController : ControllerBase, IServiceRekvisition
    {
        private readonly IRekvisitionCommand _rekvisitionCommand;
        private readonly IRekvisitionQuery _rekvisitionQuery;
        private readonly IMapper _mapper;

        public RekvisitionController(IRekvisitionCommand rekvisitionCommand, IRekvisitionQuery rekvisitionQuery, IMapper mapper)
        {
            _rekvisitionCommand = rekvisitionCommand;
            _rekvisitionQuery = rekvisitionQuery;
            _mapper = mapper;
        }

        // GET: api/<RekvisitionController> henter en list med alle rekvisitioner.
        [HttpGet]
        public async Task<IEnumerable<RekvisitionDto>> GetRekvisitionerAsync()
        {
            var rekvisition = await _rekvisitionQuery.GetRekvisitionerAsync();
            if (rekvisition == null) return null;
            return _mapper.Map<IEnumerable<RekvisitionDto>>(rekvisition);
        }

        // GET api/<RekvisitionController>/5 henter en rekvisition udfra Id
        [HttpGet("{Id}")]
        public async Task<RekvisitionDto?> GetRekvisitionAsync(int Id)
        {
            var rekvisition = await _rekvisitionQuery.GetRekvisitionAsync(Id);
            if (rekvisition is null) return null;

            return _mapper.Map<RekvisitionDto>(rekvisition);
        }

        // POST api/<RekvisitionController> opretter en rekvisition.
        [HttpPost]
        public async Task CreateRekvisitionAsync([FromBody] RekvisitionCreateDto value)
        {
            var rekvisition = _mapper.Map<RekvisitionCommandDto>(value);
            await _rekvisitionCommand.CreateAsync(rekvisition);
        }

        // PUT api/<RekvisitionController>/5 når man laver update på en rekvisition.
        [HttpPut("{Id}")]
        public async Task EditRekvisitionAsync([FromBody] RekvisitionDto value)
        {
            var rekvisition = _mapper.Map<RekvisitionCommandDto>(value);
            await _rekvisitionCommand.EditAsync(rekvisition);
        }

        // DELETE api/<RekvisitionController>/5 sletter en rekvisition udfra Id
        [HttpDelete("{Id}")]
        public async Task DeleteRekvisitionAsync(int Id)
        {
            await _rekvisitionCommand.DeleteAsync(new RekvisitionCommandDto { Id = Id });
        }
    }
}




