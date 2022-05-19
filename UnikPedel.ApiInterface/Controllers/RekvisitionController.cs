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

            //await _rekvisitionCommand.EditAsync(new RekvisitionCommandDto
            //{
            //    Id = rekvisition.Id,
            //    Type = rekvisition.Type,
            //    Beskrivelse = rekvisition.Beskrivelse,
            //    TimeCreated = rekvisition.TimeCreated,
            //    Status = rekvisition.Status,
            //    //Vicevært = rekvisition.Vicevært,
            //    // vi mangler Lejer kigge på Dto i SharedContract
            //    //Ejendom = rekvisition.Ejendom
            //});
        }

        



        // DELETE api/<RekvisitionController>/5 sletter en rekvisition udfra Id
        [HttpDelete("{Id}")]
        public async Task DeleteRekvisitionAsync(int Id)
        {
            await _rekvisitionCommand.DeleteAsync(new RekvisitionCommandDto { Id = Id });

        }

       



        // GET api/<RekvisitionController>/5 henter en rekvisition udfra Id
        [HttpGet("{Id}")]
        public async Task<RekvisitionDto?> GetRekvisitionAsync(int Id)
        {
            var rekvisition = await _rekvisitionQuery.GetRekvisitionAsync(Id);
            if (rekvisition is null) return null;
            return _mapper.Map<RekvisitionDto>(rekvisition);

            //return new RekvisitionDto
            //    {
            //      Id = rekvisition.Id,
            //      Type = rekvisition.Type,
            //      Beskrivelse = rekvisition.Beskrivelse,
            //      TimeCreated = rekvisition.TimeCreated,
            //      Status = rekvisition.Status,
            //      //Vicevært = rekvisition.Vicevært,
            //      // vi mangler Lejer kigge på Dto i SharedContract
            //      //Ejendom = rekvisition.Ejendom
            //   };

        }

     




        // GET: api/<RekvisitionController> henter en list med alle rekvisitioner.
        [HttpGet]
        public async Task<IEnumerable<RekvisitionDto>> GetRekvisitionerAsync()
        {

            var rekvisition = await _rekvisitionQuery.GetRekvisitionerAsync();
            if (rekvisition == null) return null;
            return _mapper.Map<IEnumerable<RekvisitionDto>>(rekvisition);

            //var result = new List<RekvisitionDto>();
            //var rekvisition = await _rekvisitionQuery.GetRekvisitionerAsync();
            //rekvisition.ToList()
            //    .ForEach(rekvisitioner => result.Add(new RekvisitionDto
            //    {
            //        Id = rekvisitioner.Id,
            //        Type = rekvisitioner.Type,  
            //        Beskrivelse = rekvisitioner.Beskrivelse,
            //        TimeCreated = rekvisitioner.TimeCreated,    
            //        Status = rekvisitioner.Status,  
            //        //Vicevært = rekvisitioner.Vicevært,
            //        // vi mangler Lejer kigge på Dto i SharedContract
            //        //Ejendom = rekvisitioner.Ejendom
            //    }));
            //return result;
        }



  
    }
    
}




