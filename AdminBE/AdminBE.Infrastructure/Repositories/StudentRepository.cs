using AdminBE.Domain;
using AdminBE.Domain.Entities;
using AdminBE.Infrastructure.EFContext;

namespace AdminBE.Infrastructure.Repositories;
internal class StudentRepository : IStudentRepository
{
  private readonly ApplicationDbContext _context;

  public StudentRepository(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<Student?> GetByIdAsync(int id)
  {
    return await _context.Students.FindAsync(id); // lazy loading
  }
}
