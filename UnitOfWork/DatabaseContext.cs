using Microsoft.EntityFrameworkCore;
using UnitOfWork.Model;

namespace UnitOfWork;

public class DatabaseContext : DbContext
{
  public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options) { }

#nullable disable
  public DbSet<Article> Articles { get; set; }
  public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
  public DbSet<ShoppingBasketItem> ShoppingBasketItems { get; set; }
#nullable restore

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
  }
}
