using DanceStudioManager.Data;
using DanceStudioManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DanceStudioManager.Repositories
{
    public class DanceClassRepository
    {
        private readonly AppDbContext _ctx;

        public DanceClassRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<DanceClass>> GetAllAsync()
        {
            return await _ctx.DanceClasses.AsNoTracking().ToListAsync();
        }

        public async Task<DanceClass?> GetByIdAsync(int id)
        {
            return await _ctx.DanceClasses.FindAsync(id);
        }

        public async Task AddAsync(DanceClass entity)
        {
            await _ctx.DanceClasses.AddAsync(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(DanceClass entity)
        {
            _ctx.DanceClasses.Update(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(DanceClass entity)
        {
            _ctx.DanceClasses.Remove(entity);
            await _ctx.SaveChangesAsync();
        }
    }
}
