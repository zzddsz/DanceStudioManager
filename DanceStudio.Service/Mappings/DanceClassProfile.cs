using AutoMapper;
using DanceStudio.Domain.Models;
using DanceStudio.Service.DTOs;

namespace DanceStudio.Service.Mappings
{
    public class DanceClassProfile : Profile
    {
        public DanceClassProfile()
        {
            CreateMap<DanceClassDTO, DanceClass>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Professor, opt => opt.MapFrom(src => src.Teacher))
                .ForMember(dest => dest.DiaDaSemana, opt => opt.MapFrom(src => src.DayOfWeek))
                .ForMember(dest => dest.Horario, opt => opt.MapFrom(src => src.Time))
                .ForMember(dest => dest.NumeroVagas, opt => opt.MapFrom(src => src.MaxStudents));

            CreateMap<DanceClass, DanceClassDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Professor))
                .ForMember(dest => dest.DayOfWeek, opt => opt.MapFrom(src => src.DiaDaSemana))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Horario))
                .ForMember(dest => dest.MaxStudents, opt => opt.MapFrom(src => src.NumeroVagas));
        }
    }
}