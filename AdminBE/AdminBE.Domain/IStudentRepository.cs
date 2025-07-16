using AdminBE.Domain.Entities;

namespace AdminBE.Domain;
public interface IStudentRepository
{
  Task<Student?> GetByIdAsync(int id);
}
