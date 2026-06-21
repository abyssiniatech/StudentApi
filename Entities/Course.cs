

namespace TmsApi.Entities.Models;

public class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string Code { get; set; } = null!;

    public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();
}