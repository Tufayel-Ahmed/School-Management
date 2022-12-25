using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management.Interface_Repository;
using School_Management.Models;

namespace School_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardController : ControllerBase
    {
        private readonly IStandardRepository _repository;

        public StandardController(IStandardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStandards()
        {
            try
            {
                var standards = await _repository.GetStandards();
                return Ok(standards);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStandardById([FromHeader] int id)
        {
            try
            {
                var standard = await _repository.GetStandardById(id);
                return Ok(standard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStandard([FromBody] Standard standard)
        {
            if (standard == null)
            {
                return NotFound();
            }

            try
            {
                await _repository.AddStandard(standard);
                return Ok("Standard has been Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseById(int id)
        {
            try
            {
                var standard = await _repository.DeleteStandardById(id);
                return Ok("Standard has been Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
