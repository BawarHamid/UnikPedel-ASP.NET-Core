using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikPedel.Application.LejemaalContract;
using UnikPedel.Application.LejemaalContract.Dto;
using UnikPedel.Contract.IServiceLejmaal;
using UnikPedel.Contract.IServiceLejmaal.LejemaalDtos;

namespace UnikPedel.ApiInterface.Controllers
{
    [Route("api/Lejemaal")]
    [ApiController]
    public class LejemaalController : ControllerBase, IServiceLejemaal
    {
        private readonly ILejemaalCommand _lejemaalCommand;
        private readonly ILejemaalQuery _lejemaalQuery;
        private readonly IMapper _mapper;

        public LejemaalController(ILejemaalCommand lejemaalCommand, ILejemaalQuery lejmaalQuery, IMapper mapper)
        {
            _lejemaalCommand = lejemaalCommand;
            _lejemaalQuery = lejmaalQuery;
            _mapper = mapper;
        }

        // POST api/<LejemålController> opretter en Lejemål.
        [HttpPost]
        public async Task CreateLejemaalAsync([FromBody] LejemaalCreateDto value)
        {
            var lejemaal = _mapper.Map<LejemaalCommandDto>(value);
            await _lejemaalCommand.CreateAsync(lejemaal);
        }

        // DELETE api/<LejemålController>/ sletter en Lejemål udfra Id
        [HttpDelete("{Id}")]
        public async Task DeleteLejemaalAsync(int Id)
        {
            await _lejemaalCommand.DeleteAsync(new LejemaalCommandDto { Id = Id });
        }

        // PUT api/<LejemålController>/ når man laver update på en Lejemål.
        [HttpPut("{Id}")]
        public async Task EditLejemaalAsync([FromBody] LejemaalDto value)
        {
            var lejemaal = _mapper.Map<LejemaalCommandDto>(value);
            await _lejemaalCommand.EditAsync(lejemaal);
        }

        // GET api/<LejemålController>/ henter en Lejemål udfra Id
        [HttpGet("{Id}")]
        public async Task<LejemaalDto?> GetLejemaalAsync(int Id)
        {
            var lejemaal = await _lejemaalQuery.GetLejemaalAsync(Id);
            if (lejemaal is null) return null;
            return _mapper.Map<LejemaalDto>(lejemaal);
        }

        // GET: api/<LejemålController> henter en list med alle Lejemåler.
        [HttpGet]
        public async Task<IEnumerable<LejemaalDto>> GetLejemaalAsync()
        {
            var lejemaal = await _lejemaalQuery.GetLejemaalAsync();
            if (lejemaal == null) return null;
            return _mapper.Map<IEnumerable<LejemaalDto>>(lejemaal);
        }
    }
}
