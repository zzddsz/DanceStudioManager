using DanceStudio.Domain.Models;
using DanceStudio.Repository.Data;

namespace DanceStudio.Repository.Repositories
{
    public class EnrollmentRepository : BaseRepository<Enrollment>
    {
        public EnrollmentRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
