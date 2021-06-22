using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LBSoftWebApi.Data.Core
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity item);
        Task<bool> CreateRangeAsync(IEnumerable<TEntity> items);

        Task<TEntity> FindAsync(object key, params string[] paths);

        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate);

        Task<bool> RemoveAsync(TEntity item);
        Task<bool> RemoveAsync(object key);
        Task<bool> RemoveRangeAsync(IEnumerable<TEntity> items);

        Task<TEntity> UpdateAsync(TEntity item);

        Task<IEnumerable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IEnumerable<TEntity>> GetWithIncludeAsync(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
