using UnitOfWork.Contracts;
using UnitOfWork.Model;
using UnitOfWork.Persistence;

namespace UnitOfWork;

public class BasketUnitOfWork : IDisposable, IBasketUnitOfWork
{
  private DatabaseContext _context;
  private GenericRepository<ShoppingBasket> _basketRepository;
  private GenericRepository<Article> _articleRepository;

  public BasketUnitOfWork(
    DatabaseContext context,
    GenericRepository<ShoppingBasket> basketRepository,
    GenericRepository<Article> articleRepository
    )
  {
    _context = context;
    _basketRepository = basketRepository;
    _articleRepository = articleRepository;
  }

  public GenericRepository<ShoppingBasket> ShoppingBasketRepository
    => _basketRepository;

  public GenericRepository<Article> ArticleRepository
    => _articleRepository;

  public void Save()
  {
    _context.SaveChanges();
  }

  private bool disposed = false;

  protected virtual void Dispose(bool disposing)
  {
    if (!this.disposed)
    {
      if (disposing)
      {
        _context.Dispose();
      }
    }
    this.disposed = true;
  }

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }
}
