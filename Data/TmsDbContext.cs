// using Microsoft.EntityFrameworkCore;
// using TmsApi.Entities;

// namespace TmsApi.Data;

// public class TmsDbContext(DbContextOptions<TmsDbContext> options)
//     : DbContext(options)
// {
//     public DbSet<Student> Students => Set<Student>();
//     public DbSet<Course> Courses => Set<Course>();
//     public DbSet<Enrollment> Enrollments => Set<Enrollment>();

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Enrollment>()
//             .HasKey(e => new { e.StudentId, e.CourseId });

//         base.OnModelCreating(modelBuilder);
//     }
// }







using Microsoft.EntityFrameworkCore;
using TmsApi.Entities;
using TmsApi.Entities.Models;

namespace TmsApi.Data;

public class TmsDbContext : DbContext
{
    public TmsDbContext(DbContextOptions<TmsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TmsDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}