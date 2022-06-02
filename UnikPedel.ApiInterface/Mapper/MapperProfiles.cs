using AutoMapper;
using UnikPedel.Application;
using UnikPedel.Application.BookingContract.BookingDto;
using UnikPedel.Application.Contract.Dtos;
using UnikPedel.Application.EjendomContract.EjendomDto;
using UnikPedel.Application.EjendomsAnsvarligContract.EjendomsAnsvarligDto;
using UnikPedel.Application.LejemaalContract.Dto;
using UnikPedel.Application.LejerContract.Dtos;
using UnikPedel.Application.TidRegistreringContract.TidRegistreringDto;
using UnikPedel.Contract.IServiceBooking.BookingDtos;
using UnikPedel.Contract.IServiceEjendom.EjendomDtos;
using UnikPedel.Contract.IServiceEjendomAnsvarlig.EjendomAnsvarligDtos;
using UnikPedel.Contract.IServiceLejer.LejerDtos;
using UnikPedel.Contract.IServiceLejmaal.LejemaalDtos;
using UnikPedel.Contract.IServiceRekvisition.RekvisitionDtos;
using UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos;
using UnikPedel.Contract.VicevaertDtos;
using UnikPedel.Domain.Entities;
using static UnikPedel.Contract.IServiceTidRegistrering.TidRegistreringDtos.TidRegistreringDto;

namespace UnikPedel.ApiInterface.Mapper
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<Vicevaert, VicevaertDto>().ReverseMap();
            CreateMap<VicevaertQueryDto, VicevaertDto>().ReverseMap();
            CreateMap<VicevaertDto, VicevaertCommandDto>().ReverseMap();
            CreateMap<VicevaertCreateDto, VicevaertCreateCommandDto>().ReverseMap();

            CreateMap<TidRegistering, TidRegistreringDto>().ReverseMap();
            CreateMap<TidRegistreringQueryDto, TidRegistreringDto>().ReverseMap();
            CreateMap<TidRegistreringCreateDto, TidRegistreringCommandDto>().ReverseMap();
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


            CreateMap<Lejemaal, LejemaalDto>().ReverseMap();
            CreateMap<LejemaalCommandDto, LejemaalDto>().ReverseMap();
            CreateMap<LejemaalQueryDto, LejemaalDto>().ReverseMap();
            CreateMap<LejemaalCreateDto, LejemaalCommandDto>().ReverseMap();

            CreateMap<Lejer, LejerDto>().ReverseMap();
            CreateMap<LejerQueryDto, LejerDto>().ReverseMap();
            CreateMap<LejerDto, LejerCommandDto>().ReverseMap();
            CreateMap<LejerCreateDto, LejerCreateCommandDto>().ReverseMap();
        }
    }
}
