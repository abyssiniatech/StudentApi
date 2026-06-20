using System;

namespace TmsApi.Entities.Models
{
    public class EnrollmentModel
    {
        public int Id { get; set; }   // Primary Key

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrolledAt { get; set; }
    }
}