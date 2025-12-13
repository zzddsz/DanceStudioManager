using DanceStudio.Domain.Entities;
using DanceStudio.Repository.Context;

namespace DanceStudio.Repository.Repositories
{
    public class EnrollmentRepository : BaseRepository<Enrollment>
    {
        public EnrollmentRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}