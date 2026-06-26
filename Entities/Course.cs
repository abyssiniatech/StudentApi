

// namespace TmsApi.Entities.Models;

// public class Course
// {
//     public int Id { get; set; }

//     public string Title { get; set; } = null!;
//     public string Code { get; set; } = null!;

//     public ICollection<Enrollment> Enrollments { get; set; }
//         = new List<Enrollment>();
// }


using TmsApi.Entities.Models;

public class Course
{
    public int Id { get; set; }

    public required string Code { get; set; }
    public required string Title { get; set; }
    public int MaxCapacity { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = [];
}