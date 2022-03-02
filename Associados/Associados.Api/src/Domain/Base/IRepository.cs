using System.Linq.Expressions;

namespace Associados.Api.src.Domain.Base
{
     public interface IRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetFilteredAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddListAsync(List<TEntity> entities);
        Task<bool> UpdateListAsync(List<TEntity> entities);
        Task<bool> UpdateAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
    