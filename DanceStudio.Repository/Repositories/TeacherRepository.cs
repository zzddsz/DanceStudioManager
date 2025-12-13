using DanceStudio.Domain.Entities;
using DanceStudio.Repository.Context;

namespace DanceStudio.Repository.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>
    {
        public TeacherRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}