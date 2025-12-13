using AutoMapper;
using DanceStudio.Domain.Entities;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.Base;

namespace DanceStudio.Service.Services
{
    public class EnrollmentService : BaseService<Enrollment>
    {
        public EnrollmentService(EnrollmentRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}