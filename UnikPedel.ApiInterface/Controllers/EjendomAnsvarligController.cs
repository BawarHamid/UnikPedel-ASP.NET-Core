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
        public async Task CreateEjendomAnsvarligAsync(EjendomAnsvarligDto ejendomAnsvarlig)
        {
            await _ejendomAnsvarligCommand.CreateAsync(new EjendomsAnsvarligCommandDto());
            _mapper.Map<EjendomAnsvarligDto>(ejendomAnsvarlig);

            //{
            //    Id=ejendomAnsvarlig.Id,
            //    ViceværtId=ejendomAnsvarlig.ViceværtId,
            //    EjendomId = ejendomAnsvarlig.EjendomId
            //});
        }

        // DELETE api/<EjendomAnsvarligController>/ sletter en bestemet EejendomAnsvarlig udfra Id
        [HttpDelete("{id}")]
        public async Task DeleteEjendomAnsvarligAsync(Guid Id)
        {
            await _ejendomAnsvarligCommand.DeleteAsync(new EjendomsAnsvarligCommandDto { Id = Id });
        }

        //PUT api/<EjendomAnsvarligController>/ når man laver update på en EjendomAnsvarlig.
        [HttpPut("{id}")]
        public async Task EditEjendomAnsvarligAsync(EjendomAnsvarligDto ejendomAnsvarlig)
        {


            await _ejendomAnsvarligCommand.EditAsync(new EjendomsAnsvarligCommandDto());


            _mapper.Map<EjendomAnsvarligDto>(ejendomAnsvarlig);
           

            //{
            //    Id = ejendomAnsvarlig.Id,
            //    ViceværtId = ejendomAnsvarlig.ViceværtId,
            //    Vicevært= ejendomAnsvarlig.Vicevært,
            //    EjendomId = ejendomAnsvarlig.EjendomId,
            //    Ejendom = ejendomAnsvarlig.Ejendom
            //});
            
        }


        // GET api/<EjendomController> henter en bestemt Ejendom udfra Id
        [HttpGet("{id}")]
        public async Task<EjendomAnsvarligDto?> GetEjendomAnsvarligAsync(Guid Id)
        {
            var ejendomsAnsvarlig = await _ejendomAnsvarligQuery.GetEjendomAnsvarligAsync(Id);
            if (ejendomsAnsvarlig is null) return null;
            return _mapper.Map<EjendomAnsvarligDto>(ejendomsAnsvarlig);
            //return new EjendomAnsvarligDto
            //{
            //    Id = ejendomsAnsvarlig.Id,
            //    ViceværtId = ejendomsAnsvarlig.ViceværtId,
            //    Vicevært = ejendomsAnsvarlig.Vicevært,
            //    EjendomId=ejendomsAnsvarlig.EjendomId,
            //    Ejendom = ejendomsAnsvarlig.Ejendom
            //};
           
        }


        // GET: api/<EjendomAnsvarligController> henter en list med alle EjendomAnsvarlig
        [HttpGet]
        public async Task<IEnumerable<EjendomAnsvarligDto>> GetEjendomAnsvarligAsync()
        {
            var ejendomAnsvarligListe = await _ejendomAnsvarligQuery.GetEjendomsAnsvarligAsync();

            return _mapper.Map<IEnumerable<EjendomAnsvarligDto>>(ejendomAnsvarligListe);
            //ejendomAnsvarlig.ToList();
            //    .ForEach(ejendoms => result.Add(new EjendomAnsvarligDto
            //    {
            //        Id = ejendoms.Id,
            //        ViceværtId = ejendoms.ViceværtId,
            //        Vicevært = ejendoms.Vicevært,
            //        EjendomId = ejendoms.EjendomId,
            //        Ejendom = ejendoms.Ejendom

            //    }));
            //return result;
           
        }
    }
}
