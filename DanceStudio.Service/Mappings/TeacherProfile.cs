using AutoMapper;
using DanceStudio.Domain.Models;
using DanceStudio.Service.DTOs;

namespace DanceStudio.Service.Mappings
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherDTO, Teacher>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Specialty, opt => opt.MapFrom(src => src.Speciality));

            CreateMap<Teacher, TeacherDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Speciality, opt => opt.MapFrom(src => src.Specialty));
        }
    }
}