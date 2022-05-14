using AutoMapper;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;
using UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos;
using UnikPedel.Contract.ViceværtDtos;
using UnikPedel.Domain.Entities;

namespace UnikPedel.ApiInterface.Mapper
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<Vicevært,ViceværtDto>();
            CreateMap<ViceværtCommandDto, Vicevært>();
            CreateMap<Vicevært, ViceværtCommandDto>();
            CreateMap<TidRegistering, TidRegistreringDto>();
            CreateMap<Rekvisition, RekvisitionDto>();

        }
    }
}
