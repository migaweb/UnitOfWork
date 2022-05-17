using UnitOfWork.Model;
using UnitOfWork.Persistence;

namespace UnitOfWork.Contracts
{
  public interface IBasketUnitOfWork
  {
    GenericRepository<Article> ArticleRepository { get; }
    GenericRepository<ShoppingBasket> ShoppingBasketRepository { get; }

    void Save();
  }
}