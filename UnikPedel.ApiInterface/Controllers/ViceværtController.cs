﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Application.Contract.ViceværtInterface;
using UnikPedel.Contract.IServiceVicevært;
using UnikPedel.Contract.ViceværtDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnikPedel.ApiInterface.Controllers
{
    [Route("api/Vicevært")]
    [ApiController]
    public class ViceværtController : ControllerBase, IViceværtService
    {
        private readonly IViceværtCommand _viceværtCommand;
        private readonly IViceværtQuery _viceværtQuery;
        private readonly IMapper _mapper;

        public ViceværtController(IViceværtCommand viceværtCommand, IViceværtQuery viceværtQuery, IMapper mapper)
        {
            _viceværtCommand = viceværtCommand;
            _viceværtQuery = viceværtQuery;
            _mapper = mapper;
        }

        // GET: api/<ViceværtController> henter en list med alle viceværter.
        [HttpGet]
        public async Task<IEnumerable<ViceværtDto>> GetViceværterAsync()
        {
            var vicevært = await _viceværtQuery.GetAllViceværterAsync();
            if (vicevært == null) return null;
            return _mapper.Map<IEnumerable<ViceværtDto>>(vicevært);
        }

        // GET api/<ViceværtController>/5 henter en vicevært udfra Id
        [HttpGet("{Id}")]
        public async Task<ViceværtDto?> GetViceværtAsync(int Id)
        {
            var vicevært = await _viceværtQuery.GetViceværtAsync(Id);
            if (vicevært is null) return null;

            return _mapper.Map<ViceværtDto>(vicevært);
        }

        // POST api/<ViceværtController> opretter en vicevært.
        [HttpPost]
        public async Task CreateViceværtAsync([FromBody] ViceværtCreateDto value)
        {
            var vicevært = _mapper.Map<ViceværtCreateCommandDto>(value);
            await _viceværtCommand.CreateViceværtAsyc(vicevært);
        }

        // PUT api/<ViceværtController>/5 når man laver update på en vicevært.
        [HttpPut]
        public async Task EditViceværtAsync([FromBody] ViceværtDto value)
        {
            var vicevært = _mapper.Map<ViceværtCommandDto>(value);
            await _viceværtCommand.EditViceværtAsync(vicevært);
        }

        // DELETE api/<ViceværtController>/5 sletter en vicevært udfra Id
        [HttpDelete("{Id}")]
        public async Task DeleteViceværtAsync(int Id)
        {
            await _viceværtCommand.DeleteViceværtAsync(new ViceværtCommandDto {Id = Id});
        }
    }
}
