using DanceStudio.Domain.Entities;
using DanceStudio.Repository.Context;

namespace DanceStudio.Repository.Repositories
{
    public class DanceClassRepository : BaseRepository<DanceClass>
    {
        public DanceClassRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}