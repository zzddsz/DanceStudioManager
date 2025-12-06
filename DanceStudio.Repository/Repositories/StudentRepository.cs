using DanceStudio.Domain.Models;
using DanceStudio.Repository.Data;
namespace DanceStudio.Repository.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
