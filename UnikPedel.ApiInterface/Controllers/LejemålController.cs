using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikPedel.Application.LejemålContract;
using UnikPedel.Application.LejemålContract.Dto;
using UnikPedel.Contract.IServiceLejmål;
using UnikPedel.Contract.IServiceLejmål.LejemålDtos;

namespace UnikPedel.ApiInterface.Controllers
{
    [Route("api/Lejemål")]
    [ApiController]
    public class LejemålController : ControllerBase, IServiceLejemål
    {
        private readonly ILejemålCommand _lejemålCommand;
        private readonly ILejemålQuery _lejemålQuery;
        private readonly IMapper _mapper;

        public LejemålController(ILejemålCommand lejemålCommand, ILejemålQuery lejmålQuery, IMapper mapper)
        {
            _lejemålCommand = lejemålCommand;
            _lejemålQuery = lejmålQuery;
            _mapper = mapper;
        }

        // POST api/<LejemålController> opretter en Lejemål.
        [HttpPost]
        public async Task CreateLejemålAsync([FromBody] LejemålCreateDto value)
        {
            var lejemål = _mapper.Map<LejemålCommandDto>(value);
            await _lejemålCommand.CreateAsync(lejemål);
        }

        // DELETE api/<LejemålController>/ sletter en Lejemål udfra Id
        [HttpDelete("{Id}")]
        public async Task DeleteLejemålAsync(int Id)
        {
            await _lejemålCommand.DeleteAsync(new LejemålCommandDto { Id = Id });
        }

        // PUT api/<LejemålController>/ når man laver update på en Lejemål.
        [HttpPut("{Id}")]
        public async Task EditLejemålAsync([FromBody] LejemålDto value)
        {
            var lejemål = _mapper.Map<LejemålCommandDto>(value);
            await _lejemålCommand.EditAsync(lejemål);
        }

        // GET api/<LejemålController>/ henter en Lejemål udfra Id
        [HttpGet("{Id}")]
        public async Task<LejemålDto?> GetLejemålAsync(int Id)
        {
            var lejemål = await _lejemålQuery.GetLejemålAsync(Id);
            if (lejemål is null) return null;
            return _mapper.Map<LejemålDto>(lejemål);
        }

        // GET: api/<LejemålController> henter en list med alle Lejemåler.
        [HttpGet]
        public async Task<IEnumerable<LejemålDto>> GetLejemålAsync()
        {
            var lejemål = await _lejemålQuery.GetLejemålAsync();
            if (lejemål == null) return null;
            return _mapper.Map<IEnumerable<LejemålDto>>(lejemål);
        }
    }
}
