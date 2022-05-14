using AutoMapper;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Application.EjendomsAnsvarligContract.EjendomsAnsvarligDto;
using UnikPedel.Application.TidRegistreringContract.TidRegistreringDto;
using UnikPedel.Contract.IServiceEjendomAnsvarlig.EjendomAnsvarligDtos;
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
            CreateMap<TidRegistering, TidRegistreringDto>();
            CreateMap<Rekvisition, RekvisitionDto>();

            CreateMap<ViceværtCommandDto, ViceværtDto>().ReverseMap();

            //Tidregistrering Mapping
            CreateMap<Application.TidRegistreringContract.TidRegistreringDto.TidRegistreringCommandDto, TidRegistreringDto>().
                 ForMember(dest => dest.Vicevært, opt =>
            opt.MapFrom(src => src.Vicevært)).
            ForMember(dest => dest.Rekvisition, opt => opt.MapFrom(src => src.Rekvisition)).ReverseMap();


            CreateMap<TidRegistreringQueryDto, TidRegistreringDto>().
                    ForMember(dest => dest.Vicevært, opt =>
                opt.MapFrom(src => src.Vicevært)).
                ForMember(dest => dest.Rekvisition, opt => opt.MapFrom(src => src.Rekvisition)).ReverseMap();


            //EjendomsAnsvarlig Mapping
            CreateMap<EjendomsAnsvarligCommandDto, EjendomAnsvarligDto>().
                  ForMember(dest => dest.Vicevært, opt =>
            opt.MapFrom(src => src.Vicevært)).
            ForMember(dest => dest.Ejendom, opt => opt.MapFrom(src => src.Ejendom)).ReverseMap();

            CreateMap<EjendomsAnsvarligQueryDto, EjendomAnsvarligDto>().
                  ForMember(dest => dest.Vicevært, opt =>
            opt.MapFrom(src => src.Vicevært)).
            ForMember(dest => dest.Ejendom, opt => opt.MapFrom(src => src.Ejendom)).ReverseMap();
        }
    }
}
