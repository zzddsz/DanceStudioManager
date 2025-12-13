using AutoMapper;
using DanceStudio.Domain.Entities;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.Base;

namespace DanceStudio.Service.Services
{
    public class TeacherService : BaseService<Teacher>
    {
        public TeacherService(TeacherRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}