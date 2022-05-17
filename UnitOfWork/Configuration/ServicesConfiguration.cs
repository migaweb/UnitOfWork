using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWork.Contracts;
using UnitOfWork.Persistence;

namespace UnitOfWork.Configuration;

public static class ServicesConfiguration
{
  public static void ConfigureUnitOfWork(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<DatabaseContext>(options =>
      options.UseSqlServer(
        configuration.GetConnectionString("Database")), ServiceLifetime.Transient);

    services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

    services.AddTransient<IBasketUnitOfWork, BasketUnitOfWork>();
  }
}
