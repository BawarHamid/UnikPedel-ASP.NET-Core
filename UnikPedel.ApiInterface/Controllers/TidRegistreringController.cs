using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Application.TidRegistreringContract;
using UnikPedel.Application.TidRegistreringContract.TidRegistreringDto;
using UnikPedel.Contract.IServiceTidRegistrering;
using UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnikPedel.ApiInterface.Controllers
{
    [Route("api/TidRegistrering")]
    [ApiController]
    public class TidRegistreringController : ControllerBase, IServiceTidRegistrering
    {
        private readonly ITidRegistreringCommand _tidRegCommand;
        private readonly ITidRegistreringQuery _tidRegQuery;
        private readonly IMapper _mapper;

        public TidRegistreringController(ITidRegistreringCommand tidRegCommand, ITidRegistreringQuery tidRegQuery,IMapper mapper)
        {
            _tidRegCommand = tidRegCommand; 
            _tidRegQuery = tidRegQuery;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TidRegistreringDto>> GetTidRegistreringAsync()
        {
            var tidListe = await _tidRegQuery.GetTidRegistreringAsync();
            return _mapper.Map<IEnumerable<TidRegistreringDto>>(tidListe);

        }


        [HttpDelete("{Id}")]
        public async Task DeleteTidRegistreringAsync(int id)
        {
            await _tidRegCommand.DeleteRegistreringAsync(new TidRegistreringCommandDto { Id = id });
        }

        [HttpPost]
        public async Task CreateTidRegistreringAsync([FromBody] TidRegistreringCreateDto tidRegistrering)
        {
           var registrering=_mapper.Map<TidRegistreringCommandDto>(tidRegistrering);
            await _tidRegCommand.CreateTidRegistreringAsyc(registrering);

            
        }
       

        [HttpPut("{Id}")]
        public async Task EditTidRegistreringAsync(TidRegistreringDto tidRegistrering)
        {
            _mapper.Map<TidRegistreringCommandDto>(tidRegistrering);
            await _tidRegCommand.EditRegistreringAsync(new TidRegistreringCommandDto());
         
        }

        [HttpGet("{Id}")]
        public async Task<TidRegistreringDto?> GetTidRegistreringAsync(int Id)
        {
            var registrering = await _tidRegQuery.GetTidRegistreringAsync(Id);
            if (registrering == null) return null;
            return _mapper.Map<TidRegistreringDto?>(registrering);
        }

       
    }
}
