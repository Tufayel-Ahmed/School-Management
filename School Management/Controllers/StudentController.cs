using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management.Interface_Repository;
using School_Management.Models;

namespace School_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository= repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _repository.GetStudents();
                return Ok(students);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromHeader] int id)
        {
            try
            {
                var student = await _repository.GetStudentById(id);
                return Ok(student);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return NotFound();
            }

            try
            {
                await _repository.AddStudent(student);
                return Ok("Student has been Added");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentById(int id)
        {
            try
            {
                var student = await _repository.DeleteStudent(id);
                return Ok("Student has been Deleted");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
