using DanceStudio.Domain.Base;
using DanceStudio.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanceStudio.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity<int>
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dataset;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dataset = _context.Set<TEntity>();
        }

        // ================= ADD =================
        public async Task InsertAsync(TEntity entity)
        {
            await _dataset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // ================= UPDATE =================
        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // ================= DELETE (CORRIGIDO) =================
        public async Task DeleteAsync(int id)
        {
            var entity = Activator.CreateInstance<TEntity>();
            entity.Id = id;

            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        // ================= GET ALL =================
        public async Task<IList<TEntity>> SelectAsync(IList<string>? includes = null)
        {
            IQueryable<TEntity> query = _dataset;

            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        // ================= GET BY ID =================
        public async Task<TEntity> SelectAsync(int id, IList<string>? includes = null)
        {
            IQueryable<TEntity> query = _dataset;

            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }

            return await query
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
