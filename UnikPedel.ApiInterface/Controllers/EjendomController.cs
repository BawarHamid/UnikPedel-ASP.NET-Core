using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikPedel.Application.EjendomContract;
using UnikPedel.Contract.IServiceEjendom;
using UnikPedel.Contract.IServiceEjendom.EjendomDtos;

namespace UnikPedel.ApiInterface.Controllers
{
    [Route("api/Ejendom")]
    [ApiController]
    public class EjendomController : ControllerBase, IServiceEjendom
    {
        private readonly IEjendomQuery _ejendomQuery;
        private readonly IMapper _mapper;
        public EjendomController(IEjendomQuery ejendomQuery, IMapper mapper)
        {
            _ejendomQuery = ejendomQuery;
            _mapper = mapper;   
        }


        // GET api/<EjendomController> henter en bestemt Ejendom udfra Id
        [HttpGet("{Id}")]
        public async Task<EjendomDto?> GetEjendomAsync(int Id)
        {
            var ejendom = await _ejendomQuery.GetEjendom(Id);
            if (ejendom is null) return null;
            return _mapper.Map<EjendomDto>(ejendom);
        }

        // GET: api/<EjendomController> henter en list med alle Ejendom
        [HttpGet]
        public async Task<IEnumerable<EjendomDto>> GetEjendomAsync()
        {
            var ejendom = await _ejendomQuery.GetEjendoms();         
            return _mapper.Map<IEnumerable<EjendomDto>>(ejendom); 
        }
    }
}

