namespace UnitOfWork.Model;

public class Article : BaseDomainEntity
{
  public long ArticleNo { get; set; }
  public string? Name { get; set; }
}
