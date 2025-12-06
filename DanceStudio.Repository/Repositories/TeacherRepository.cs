using DanceStudio.Domain.Models;
using DanceStudio.Repository.Data;

namespace DanceStudio.Repository.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>
    {
        public TeacherRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}