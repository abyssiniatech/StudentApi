using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    static List<Student> students =
    [
        new Student
        {
            Id = 1,
            Name = "Abebe",
            Age = 20
        },
        new Student
        {
            Id = 2,
            Name = "Kebede",
            Age = 22
        },
        new Student
        {
            Id = 3,
            Name = "Alemu",
            Age = 21
        },
        new Student
        {
            Id = 4,
            Name = "Mulu",
            Age = 19
        },
        new Student
        {
            Id = 5,
            Name = "Sisay",
            Age = 23
        },
        new Student
        {
            Id = 6,
            Name = "Tadesse",
            Age = 20
        },
    ];

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(students);
    }
}






