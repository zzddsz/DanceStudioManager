using AutoMapper;
using DanceStudioManager.Models;
using DanceStudioManager.DTOs;

namespace DanceStudioManager.Mappings
{
    public class DanceClassProfile : Profile
    {
        public DanceClassProfile()
        {
            CreateMap<DanceClass, DanceClassDTO>().ReverseMap();
        }
    }
}
