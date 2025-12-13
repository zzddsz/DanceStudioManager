using AutoMapper;
using DanceStudio.Domain.Entities;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.Base;

namespace DanceStudio.Service.Services
{
    public class DanceClassService : BaseService<DanceClass>
    {
        public DanceClassService(DanceClassRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}