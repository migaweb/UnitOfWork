using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UnitOfWork.Contracts;
using UnitOfWork.Model;

namespace UnitOfWork.Persistence;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDomainEntity
{
  private readonly DatabaseContext _dbContext;
  internal DbSet<TEntity> _dbSet;

  public GenericRepository(DatabaseContext dbContext)
  {
    _dbContext = dbContext;
    _dbSet = dbContext.Set<TEntity>();
  }

  public void AddAsync(TEntity entity)
  {
    _dbSet.Add(entity);
  }

  public async Task DeleteAsync(int id)
  {
    TEntity? entityToDelete = await _dbSet.FindAsync(id);

    if (entityToDelete == null) return;

    if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
    {
      _dbSet.Attach(entityToDelete);
    }

    _dbSet.Remove(entityToDelete);
  }

  public async Task<bool> ExistsAsync(int id)
  {
    var entity = await GetAsync(id);

    return entity != null;
  }

  public IEnumerable<TEntity> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
{
    IQueryable<TEntity> query = _dbSet;

    if (filter != null)
    {
      query = query.Where(filter);
    }

    foreach (var includeProperty in includeProperties.Split
        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
    {
      query = query.Include(includeProperty);
    }

    if (orderBy != null)
    {
      return orderBy(query).ToList();
    }
    else
    {
      return query.ToList();
    }
  }

  public async Task<TEntity?> GetAsync(int id)
    => await _dbSet.FindAsync(id);

  public void UpdateAsync(int id, TEntity entity)
  {
    _dbSet.Attach(entity);
    _dbContext.Entry(entity).State = EntityState.Modified;
  }
}

