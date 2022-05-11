using AutoMapper;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos;
using UnikPedel.Contract.ViceværtDtos;


namespace UnikPedel.ApiInterface.Mapper
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<ViceværtCommandDto,ViceværtDto>();
            CreateMap<Application.TidRegistreringContract.TidRegistreringDto.TidRegistreringCommandDto, TidRegistreringDto>();
        }
    }
}
