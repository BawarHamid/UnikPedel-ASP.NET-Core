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
            CreateMap<Vicevært,ViceværtDto>().ReverseMap();
            CreateMap<ViceværtCommandDto, Vicevært>().ReverseMap();
            CreateMap<TidRegistering, TidRegistreringDto>().ReverseMap();
            CreateMap<Rekvisition, RekvisitionDto>().ReverseMap();
            CreateMap<ViceværtCommandDto, ViceværtDto>().ReverseMap();
            CreateMap<ViceværtQueryDto, ViceværtDto>().ReverseMap();
        }
    }
}
