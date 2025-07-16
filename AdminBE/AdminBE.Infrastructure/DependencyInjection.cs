using AdminBE.Application.RepositoryInterfaces;
using AdminBE.Domain;
using AdminBE.Infrastructure.EFContext;
using AdminBE.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminBE.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(
      this IServiceCollection services,
      IConfiguration configuration)
  {
    services.AddScoped<IStudentRepository, StudentRepository>();
    services.AddDatabase(configuration);

    return services; // Registering the database context and repositories
  }

  private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
  {
    string? connectionString = configuration.GetConnectionString("Database");

    services.AddDbContext<ApplicationDbContext>(
        options => options
            .UseSqlServer(connectionString));

    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));


    return services;
  }
}
