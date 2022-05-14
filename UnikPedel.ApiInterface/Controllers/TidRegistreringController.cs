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


        [HttpDelete("{id}")]
        public async Task DeleteTidRegistreringAsync(Guid id)
        {
            await _tidRegCommand.DeleteRegistreringAsync(new TidRegistreringCommandDto { Id = id });
        }

        [HttpPost]
        public async Task CreateTidRegistreringAsync([FromBody] TidRegistreringDto tidRegistrering)
        {
           
            await _tidRegCommand.CreateTidRegistreringAsyc(new TidRegistreringCommandDto ());

            _mapper.Map<TidRegistreringCommandDto>(tidRegistrering);
            
        }
       

        [HttpPut("{id}")]
        public async Task EditTidRegistreringAsync(TidRegistreringDto tidRegistrering)
        {
            await _tidRegCommand.EditRegistreringAsync(new TidRegistreringCommandDto());
            _mapper.Map<TidRegistreringCommandDto>(tidRegistrering);
        }

        [HttpGet("{id}")]
        public async Task<TidRegistreringDto?> GetTidRegistreringAsync(Guid Id)
        {
            var registrering = await _tidRegQuery.GetTidRegistreringAsync(Id);
            if (registrering == null) return null;
            return _mapper.Map<TidRegistreringDto?>(registrering);
            //    new TidRegistreringDto
            //{
            //    //Id = registrering.Id,
            //    //AntalTimer = registrering.AntalTimer,
            //    //RegisterDato = registrering.RegisterDato,
            //    //Vicevært = registrering.Vicevært,
            //    //Rekvisition = registrering.Rekvisition

            //};
        }

       
    }
}
