using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TmsApi.Data;
using TmsApi.Entities.Models;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentController : ControllerBase
{
    private readonly TmsDbContext _context;

    public EnrollmentController(TmsDbContext context)
    {
        _context = context;
    }

    // GET: api/enrollments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments()
    {
        return await _context.Enrollments.ToListAsync();
    }

    // GET: api/enrollments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Enrollment>> GetEnrollment(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);

        if (enrollment == null)
            return NotFound("Enrollment not found");

        return enrollment;
    }

    // POST: api/enrollments
    [HttpPost]
    public async Task<ActionResult<Enrollment>> CreateEnrollment(Enrollment enrollment)
    {
        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id }, enrollment);
    }

    // PUT: api/enrollments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEnrollment(int id, Enrollment enrollment)
    {
        if (id != enrollment.Id)
            return BadRequest("ID mismatch");

        _context.Entry(enrollment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EnrollmentExists(id))
                return NotFound("Enrollment not found");
            else
                throw;
        }
        return NoContent();
    }

    private bool EnrollmentExists(int id)
    {
        return _context.Enrollments.Any(e => e.Id == id);
    }

    // DELETE: api/enrollments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnrollment(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment == null)
            return NotFound("Enrollment not found");

        _context.Enrollments.Remove(enrollment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
