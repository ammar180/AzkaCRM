using AdminBE.Application.DTOs;

namespace AdminBE.Application.ServiceInterfaces;
public interface IStudentService
{
  Task<StudentDTO?> GetByIdAsync(int id);
}
