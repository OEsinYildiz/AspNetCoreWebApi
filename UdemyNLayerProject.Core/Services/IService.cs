using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Core.Services
{
    public interface IService<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> AddAsync(TEntity entity);
        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(ICollection<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}