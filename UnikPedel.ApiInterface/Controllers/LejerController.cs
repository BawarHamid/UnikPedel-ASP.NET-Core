using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikPedel.Application.LejerContract;
using UnikPedel.Application.LejerContract.Dtos;
using UnikPedel.Contract.IServiceLejer;
using UnikPedel.Contract.IServiceLejer.LejerDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnikPedel.ApiInterface.Controllers
{
    [Route("api/Lejer")]
    [ApiController]
    public class LejerController : ControllerBase, ILejerService
    {
        private readonly ILejerCommand _lejerCommand;
        private readonly ILejerQuery _LejerQuery;
        private readonly IMapper _mapper;

        public LejerController(ILejerCommand lejerCommand, ILejerQuery LejerQuery, IMapper mapper)
        {
            _lejerCommand = lejerCommand;
            _LejerQuery = LejerQuery;
            _mapper = mapper;
        }

        // GET: api/<LejerController>
        [HttpGet]
        public async Task<IEnumerable<LejerDto>> GetLejereAsync()
        {
            var lejer = await _LejerQuery.GetAllLejereAsync();
            if (lejer == null) return null;
            return _mapper.Map<IEnumerable<LejerDto>>(lejer);
        }

        // GET api/<LejerController>/5
        [HttpGet("{Id}")]
        public async Task<LejerDto?> GetLejerAsync(int Id)
        {
            var lejer = await _LejerQuery.GetLejerAsync(Id);
            if (lejer is null) return null;

            return _mapper.Map<LejerDto>(lejer);
        }

        // POST api/<LejerController>
        [HttpPost]
        public async Task CreateLejerAsync([FromBody] LejerCreateDto value)
        {
            var lejer = _mapper.Map<LejerCreateCommandDto>(value);
            await _lejerCommand.CreateLejerAsync(lejer);
        }

        // PUT api/<LejerController>/5
        [HttpPut]
        public async Task EditLejerAsync([FromBody] LejerDto value)
        {
            var lejer = _mapper.Map<LejerCommandDto>(value);
            await _lejerCommand.EditLejerAsync(lejer);
        }

        // DELETE api/<LejerController>/5
        [HttpDelete("{Id}")]
        public async Task DeleteLejerAsync(int Id)
        {
            await _lejerCommand.DeleteLejerAsync(new LejerCommandDto { Id = Id });
        }

        
    }
}
