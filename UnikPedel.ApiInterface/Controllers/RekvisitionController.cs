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

            public RekvisitionController(IRekvisitionCommand rekvisitionCommand, IRekvisitionQuery rekvisitionQuery)
            {
                _rekvisitionCommand = rekvisitionCommand;
                _rekvisitionQuery = rekvisitionQuery;
            }

        // POST api/<RekvisitionController> opretter en rekvisition.
        [HttpPost]
            public async Task CreateRekvisitionAsync(RekvisitionDto rekvisition)
            {
               await _rekvisitionCommand.CreateAsync(new RekvisitionCommandDto
               {
                   Id = rekvisition.Id,
                   Type = rekvisition.Type,
                   Beskrivelse = rekvisition.Beskrivelse,
                   TimeCreated = rekvisition.TimeCreated,
                   Status = rekvisition.Status,
                   //Vicevært = rekvisition.Vicevært,
                   // vi mangler Lejer kigge på Dto i SharedContract
                   //Ejendom = rekvisition.Ejendom
               });
            }



        // PUT api/<RekvisitionController>/5 når man laver update på en rekvisition.
        [HttpPut("{id}")]
            public async Task EditRekvisitionAsync(RekvisitionDto rekvisition)
            {
               await _rekvisitionCommand.EditAsync(new RekvisitionCommandDto
               {
                   Id = rekvisition.Id,
                   Type = rekvisition.Type,
                   Beskrivelse = rekvisition.Beskrivelse,
                   TimeCreated = rekvisition.TimeCreated,
                   Status = rekvisition.Status,
                   //Vicevært = rekvisition.Vicevært,
                   // vi mangler Lejer kigge på Dto i SharedContract
                   //Ejendom = rekvisition.Ejendom
               });

            }


        // DELETE api/<RekvisitionController>/5 sletter en rekvisition udfra Id
        [HttpDelete("{id}")]
            public async Task DeleteRekvisitionAsync(Guid Id)
            {
               await _rekvisitionCommand.DeleteAsync(new RekvisitionCommandDto { Id = Id });
           
            }



        // GET api/<RekvisitionController>/5 henter en rekvisition udfra Id
        [HttpGet("{id}")]
            public async Task<RekvisitionDto?> GetRekvisitionAsync(Guid Id)
            {
                var rekvisition = await _rekvisitionQuery.GetRekvisitionAsync(Id);
                if (rekvisition is null) return null;
                return new RekvisitionDto
                {
                  Id = rekvisition.Id,
                  Type = rekvisition.Type,
                  Beskrivelse = rekvisition.Beskrivelse,
                  TimeCreated = rekvisition.TimeCreated,
                  Status = rekvisition.Status,
                  //Vicevært = rekvisition.Vicevært,
                  // vi mangler Lejer kigge på Dto i SharedContract
                  //Ejendom = rekvisition.Ejendom
               };
           
            }


        // GET: api/<RekvisitionController> henter en list med alle rekvisitioner.
        [HttpGet]
            public async Task<IEnumerable<RekvisitionDto>> GetRekvisitionerAsync()
            {
            var result = new List<RekvisitionDto>();
            var rekvisition = await _rekvisitionQuery.GetRekvisitionerAsync();
            rekvisition.ToList()
                .ForEach(rekvisitioner => result.Add(new RekvisitionDto
                {
                    Id = rekvisitioner.Id,
                    Type = rekvisitioner.Type,  
                    Beskrivelse = rekvisitioner.Beskrivelse,
                    TimeCreated = rekvisitioner.TimeCreated,    
                    Status = rekvisitioner.Status,  
                    //Vicevært = rekvisitioner.Vicevært,
                    // vi mangler Lejer kigge på Dto i SharedContract
                    //Ejendom = rekvisitioner.Ejendom
                }));
            return result;
            }
    }
    
}




