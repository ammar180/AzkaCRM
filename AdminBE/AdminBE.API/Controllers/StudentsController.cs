using AdminBE.API.Models.ResponseModels;
using AdminBE.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminBE.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
  private readonly IStudentService _studentService;

  public StudentsController(IStudentService studentService)
  {
    _studentService = studentService;
  }
  [HttpGet("{id}")]
  public async Task<ActionResult<StudentResponse>> GetStudentById(int id)
  {
    try
    {
      var student = await _studentService.GetByIdAsync(id);
      return Ok(student as StudentResponse);
    }
    catch(NullReferenceException ex)
    {
      return NotFound(ex.Message);
    }

  }
}
