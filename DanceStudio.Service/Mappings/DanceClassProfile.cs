using AutoMapper;
using DanceStudio.Domain.Models;
using DanceStudio.Service.DTOs;

namespace DanceStudio.Service.Mappings
{
    // A classe do perfil deve herdar de Profile
    public class DanceClassProfile : Profile
    {
        public DanceClassProfile()
        {
            // Mapeamento da Entidade para o DTO
            CreateMap<DanceClass, DanceClassDTO>().ReverseMap();

            // Você pode adicionar mapeamentos específicos aqui se necessário.
            // Exemplo:
            // CreateMap<DanceClass, DanceClassDTO>()
            //    .ForMember(dest => dest.NomeDaAula, opt => opt.MapFrom(src => src.Nome));
        }
    }
}