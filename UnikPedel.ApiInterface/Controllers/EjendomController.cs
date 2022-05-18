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
            return new EjendomDto
            {
                Id = ejendom.Id,
                VejNavn = ejendom.VejNavn,
                BygningsNummer = ejendom.BygningsNummer,
                PostNummer = ejendom.PostNummer,
                By = ejendom.By,
                Region = ejendom.Region,
                LandKode = ejendom.LandKode

            };
        }

        // GET: api/<EjendomController> henter en list med alle Ejendom
        [HttpGet]
        public async Task<IEnumerable<EjendomDto>> GetEjendomAsync()
        {
            var ejendom = await _ejendomQuery.GetEjendoms();         
            return _mapper.Map<IEnumerable<EjendomDto>>(ejendom); 



            //var result = new List<EjendomDto>();
            //var ejendom = await _ejendomQuery.GetEjendoms();
            //ejendom.ToList().ForEach(a => result.Add(new EjendomDto
            //{
            //    Id = a.Id,
            //    VejNavn = a.VejNavn,
            //    BygningsNummer = a.BygningsNummer,
            //    PostNummer = a.PostNummer,
            //    By = a.By,
            //    Region = a.Region,
            //    LandKode = a.LandKode
            //}));
            //return result;
        }
    }
}

