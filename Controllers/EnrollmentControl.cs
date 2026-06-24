using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TmsApi.Data;
using TmsApi.Entities.Models;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentsController : ControllerBase
{
    private readonly TmsDbContext _dbContext;

    public EnrollmentsController(TmsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: api/enrollments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments()
    {
        return await _dbContext.Enrollments.ToListAsync();
    }

    // GET: api/students/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await _dbContext.Students.FindAsync(id);

        if (student == null)
            return NotFound("Student not found");

        return student;
    }

    // POST: api/students
    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent(Student student)
    {
        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    // PUT: api/students/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, Student student)
    {
        if (id != student.Id)
            return BadRequest("ID mismatch");

        _dbContext.Entry(student).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/students/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _dbContext.Students.FindAsync(id);

        if (student == null)
            return NotFound();

        _dbContext.Students.Remove(student);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    private bool StudentExists(int id)
    {
        return _dbContext.Students.Any(e => e.Id == id);
    }


    // soft delete method
    [HttpDelete("soft/{id}")]
    public async Task<IActionResult> SoftDeleteStudent(int id)
    {
        var student = await _dbContext.Students.FindAsync(id);

        if (student == null)
            return NotFound();

        student.IsActive = false; // Assuming IsActive is a property in the Student model
        _dbContext.Entry(student).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}