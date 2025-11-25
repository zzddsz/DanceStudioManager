using AutoMapper;
using DanceStudio.Domain.Models;
using DanceStudio.Service.DTOs;

namespace DanceStudio.Service.Mappings
{
    public class DanceClassProfile : Profile
    {
        public DanceClassProfile()
        {
            CreateMap<DanceClass, DanceClassDTO>().ReverseMap();
        }
    }
}