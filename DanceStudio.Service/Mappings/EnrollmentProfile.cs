using AutoMapper;
using DanceStudio.Domain.Models;
using DanceStudio.Service.DTOs;

namespace DanceStudio.Service.Mappings
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentDTO>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.Name)) 
                .ForMember(dest => dest.DanceClassName, opt => opt.MapFrom(src => src.DanceClass.Nome));

            CreateMap<EnrollmentDTO, Enrollment>()
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.DanceClass, opt => opt.Ignore())

                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.DanceClassId, opt => opt.MapFrom(src => src.DanceClassId));
        }
    }
}