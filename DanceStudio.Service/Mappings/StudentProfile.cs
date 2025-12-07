using AutoMapper;
using DanceStudio.Domain.Models;
using DanceStudio.Service.DTOs;

namespace DanceStudio.Service.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentDTO, Student>().ReverseMap();
        }
    }
}