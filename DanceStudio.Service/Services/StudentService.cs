using AutoMapper;
using DanceStudio.Domain.Entities;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.Base;

namespace DanceStudio.Service.Services
{
    public class StudentService : BaseService<Student>
    {
        public StudentService(StudentRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}