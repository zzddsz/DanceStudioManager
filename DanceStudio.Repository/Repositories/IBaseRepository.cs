using DanceStudio.Domain.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanceStudio.Repository.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity<int>
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);

        Task<IList<TEntity>> SelectAsync(IList<string>? includes = null);
        Task<TEntity> SelectAsync(int id, IList<string>? includes = null);
    }
}
