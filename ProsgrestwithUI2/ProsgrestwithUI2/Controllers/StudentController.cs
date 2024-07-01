using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsgrestwithUI2.Context;
using ProsgrestwithUI2.Model;

namespace ProsgrestwithUI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _dbContext.Stu.ToListAsync();
            return Ok(students);
        }

        [HttpGet("GetStudent/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _dbContext.Stu.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Stu.Add(student);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(student).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Stu.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _dbContext.Stu.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _dbContext.Stu.Remove(student);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
