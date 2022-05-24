using AutoMapper;
using UnikPedel.Application;
using UnikPedel.Application.BookingContract.BookingDto;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Application.EjendomContract.EjendomDto;
using UnikPedel.Application.EjendomsAnsvarligContract.EjendomsAnsvarligDto;
using UnikPedel.Application.LejemålContract.Dto;
using UnikPedel.Application.TidRegistreringContract.TidRegistreringDto;
using UnikPedel.Contract.IServiceBooking.BookingDtos;
using UnikPedel.Contract.IServiceEjendom.EjendomDtos;
using UnikPedel.Contract.IServiceEjendomAnsvarlig.EjendomAnsvarligDtos;
using UnikPedel.Contract.IServiceLejmål.LejemålDtos;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;
using UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos;
using UnikPedel.Contract.ViceværtDtos;
using UnikPedel.Domain.Entities;
using static UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos.TidRegistreringDto;

namespace UnikPedel.ApiInterface.Mapper
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<Vicevært,ViceværtDto>().ReverseMap();
            CreateMap<ViceværtCommandDto, Vicevært>().ReverseMap();
            CreateMap<ViceværtCommandDto, ViceværtDto>().ReverseMap();
            CreateMap<ViceværtQueryDto, ViceværtDto>().ReverseMap();

           
            CreateMap<TidRegistering, TidRegistreringDto>().ReverseMap();
            CreateMap<TidRegistreringQueryDto, TidRegistreringDto>().ReverseMap();
            CreateMap<TidRegistreringCreateDto,TidRegistreringCommandDto >().ReverseMap();
            CreateMap<TidRegistreringDto, TidRegistreringCommandDto>().ReverseMap();

            CreateMap<Rekvisition, RekvisitionDto>().ReverseMap();
            CreateMap<RekvisitionCommandDto, RekvisitionDto>().ReverseMap();
            CreateMap<RekvisitionQueryDto, RekvisitionDto>().ReverseMap();
            CreateMap<RekvisitionCreateDto, RekvisitionCommandDto>().ReverseMap();   

           
            CreateMap<EjendomQueryDto, EjendomDto>().ReverseMap();

            CreateMap<EjendomsAnsvarligCommandDto, EjendomAnsvarligDto>().ReverseMap();
            CreateMap<EjendomsAnsvarligCommandDto, EjendomAnsvarligCreateDto>().ReverseMap();
            CreateMap<EjendomsAnsvarligQueryDto, EjendomAnsvarligDto>().ReverseMap();

            CreateMap<BookingCommandDto, BookingDto>().ReverseMap();
            CreateMap<BookingCommandDto, BookingCreateDto>().ReverseMap();
            CreateMap<BookingQueryDto, BookingDto>().ReverseMap();


            CreateMap<Lejemål, LejemålDto>().ReverseMap();
            CreateMap<LejemålCommandDto, LejemålDto>().ReverseMap();
            CreateMap<LejemålQueryDto, LejemålDto>().ReverseMap();
            CreateMap<LejemålCreateDto, LejemålCommandDto>().ReverseMap();
        }
    }
}
