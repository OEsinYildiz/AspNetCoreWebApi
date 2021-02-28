using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Core.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class //TEntity class olmak zorunda
    {
        //Burada tum modeller icin metotlar yaziyoruz.
        Task<TEntity> GetByIdAsync(int id);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(ICollection<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}