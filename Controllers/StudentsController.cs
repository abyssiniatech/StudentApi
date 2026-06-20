using Microsoft.AspNetCore.Mvc;
using TmsApi.Models;

namespace TmsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    static List<Student> students =
    [
        new Student { Id = 1, FullName = "Abebe", Age = 20 },
        new Student { Id = 2, FullName = "Kebede", Age = 22 },
        new Student { Id = 3, FullName = "Alemu", Age = 21 },
        new Student { Id = 4, FullName = "Mulu", Age = 19 },
        new Student { Id = 5, FullName = "Sisay", Age = 23 },
        new Student { Id = 6, FullName = "Tadesse", Age = 20 },
    ];

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(students);
    }
}