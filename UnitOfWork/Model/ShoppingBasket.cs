namespace UnitOfWork.Model;

public class ShoppingBasket : BaseDomainEntity
{
  public Guid Identification { get; set; }

  public ICollection<ShoppingBasketItem> Items { get; set; } = new List<ShoppingBasketItem>();
}