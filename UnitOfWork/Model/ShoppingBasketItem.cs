namespace UnitOfWork.Model;

public class ShoppingBasketItem : BaseDomainEntity
{
  public int LineId { get; set; }
  public string? ArticleName { get; set; }
}
