using Microsoft.AspNetCore.Mvc;
using shereeni_dotnet.Models;

namespace shereeni_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    [HttpGet(Name = "GetAllStudents")]
    public ActionResult<IEnumerable<Student>> Get()
    {
        // OK - 200
        return Ok(StudentRepository.Students);
    }

    [HttpGet("{id:int}", Name = "GetStudentById")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public ActionResult<Student> GetStudentById(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var student = StudentRepository.Students.Where(n => n.Id == id).FirstOrDefault();
        
        if (student == null)
        {
            return NotFound($"The student with the provided id {id} doesnt exists.");
        }
        
        return Ok(student);
    }

    [HttpPost]
    public ActionResult<StudentDTO> CreateNewStudent([FromBody] StudentDTO? model)
    {
        if (model == null)
        {
            return BadRequest("BADDD REquest");
        }

        // if (model.AdmissionDate < DateTime.Now)
        // {
        //     ModelState.AddModelError("AdmissionDate", "Admission date must be greater than today date.");
        //     return BadRequest(ModelState);
        // }

        int newId = StudentRepository.Students.LastOrDefault().Id + 1;

        Student student = new Student
        {
            Id = newId,
            Name = model.Name,
            Email = model.Email,
            Address = model.Address,
        };
        
        StudentRepository.Students.Add(student);
        // model.Id = student.Id;
        
        return Ok(student);
    }
}