using System.Linq.Expressions;
using UnitOfWork.Model;

namespace UnitOfWork.Contracts;
public interface IGenericRepository<TEntity> where TEntity : BaseDomainEntity
{
  Task<TEntity?> GetAsync(int id);
  IEnumerable<TEntity> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");
  void AddAsync(TEntity entity);
  void UpdateAsync(int id, TEntity entity);
  Task DeleteAsync(int id);
  Task<bool> ExistsAsync(int id);
}

