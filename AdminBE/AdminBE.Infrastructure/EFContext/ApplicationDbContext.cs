using AdminBE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminBE.Infrastructure.EFContext;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
  public DbSet<Student> Students { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
  }
}
