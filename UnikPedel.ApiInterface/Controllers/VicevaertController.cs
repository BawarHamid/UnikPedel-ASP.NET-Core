using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Application.Contract.VicevaertInterface;
using UnikPedel.Contract.IServiceVicevaert;
using UnikPedel.Contract.VicevaertDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnikPedel.ApiInterface.Controllers
{
    [Route("api/Vicevaert")]
    [ApiController]
    public class VicevaertController : ControllerBase, IVicevaertService
    {
        private readonly IVicevaertCommand _vicevaertCommand;
        private readonly IVicevaertQuery _vicevaertQuery;
        private readonly IMapper _mapper;

        public VicevaertController(IVicevaertCommand vicevaertCommand, IVicevaertQuery vicevaertQuery, IMapper mapper)
        {
            _vicevaertCommand = vicevaertCommand;
            _vicevaertQuery = vicevaertQuery;
            _mapper = mapper;
        }

        // GET: api/<ViceværtController> henter en list med alle viceværter.
        [HttpGet]
        public async Task<IEnumerable<VicevaertDto>> GetVicevaerterAsync()
        {
            var vicevaert = await _vicevaertQuery.GetAllVicevaerterAsync();
            if (vicevaert == null) return null;
            return _mapper.Map<IEnumerable<VicevaertDto>>(vicevaert);
        }

        // GET api/<ViceværtController>/5 henter en vicevært udfra Id
        [HttpGet("{Id}")]
        public async Task<VicevaertDto?> GetVicevaertAsync(int Id)
        {
            var vicevaert = await _vicevaertQuery.GetVicevaertAsync(Id);
            if (vicevaert is null) return null;

            return _mapper.Map<VicevaertDto>(vicevaert);
        }

        // POST api/<ViceværtController> opretter en vicevært.
        [HttpPost]
        public async Task CreateVicevaertAsync([FromBody] VicevaertCreateDto value)
        {
            var vicevaert = _mapper.Map<VicevaertCreateCommandDto>(value);
            await _vicevaertCommand.CreateVicevaertAsyc(vicevaert);
        }

        // PUT api/<ViceværtController>/5 når man laver update på en vicevært.
        [HttpPut]
        public async Task EditVicevaertAsync([FromBody] VicevaertDto value)
        {
            var vicevaert = _mapper.Map<VicevaertCommandDto>(value);
            await _vicevaertCommand.EditVicevaertAsync(vicevaert);
        }

        // DELETE api/<ViceværtController>/5 sletter en vicevært udfra Id
        [HttpDelete("{Id}")]
        public async Task DeleteVicevaertAsync(int Id)
        {
            await _vicevaertCommand.DeleteVicevaertAsync(new VicevaertCommandDto {Id = Id});
        }
    }
}
