using DanceStudio.Domain.Entities;
using DanceStudio.Repository.Context;
namespace DanceStudio.Repository.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
