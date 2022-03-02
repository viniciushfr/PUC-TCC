using System.Linq.Expressions;
using Associados.Api.src.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Associados.Api.src.Infra.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public IQueryable<TEntity> GetFilteredAsync (Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).AsQueryable<TEntity>();
        }
        public virtual async Task<TEntity> GetByIdAsync(Guid id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public virtual async Task<bool> AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            return await SaveChangesAsync() > 0;
        }

        public async Task<bool> AddListAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return await SaveChangesAsync() == entities.Count();
        }

        public async Task<bool> UpdateListAsync(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            return await SaveChangesAsync() == entities.Count();
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await SaveChangesAsync() > 0;
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        public IQueryable<TEntity> GetFilteredAsync()
        {
            throw new NotImplementedException();
        }
    }
}