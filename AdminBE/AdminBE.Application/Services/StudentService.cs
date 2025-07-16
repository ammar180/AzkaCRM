using AdminBE.Application.DTOs;
using AdminBE.Application.ServiceInterfaces;
using AdminBE.Domain;

namespace AdminBE.Application.Services;

public class StudentService : IStudentService
{
  private readonly IStudentRepository _studentRepository;

  public StudentService(IStudentRepository studentRepository)
  {
    _studentRepository = studentRepository;
  }

  public async Task<StudentDTO?> GetByIdAsync(int id)
  {
    // business logic and flow handling
    var student = await _studentRepository.GetByIdAsync(id)
                    ?? throw new NullReferenceException("Student can't be null");

    return new StudentDTO
    {
      Id = student.Id,
      Name = student.Name,
      Age = student.Age,
      Email = student.Email
    };
  }
}
