using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace G_NET_91_EF03.Models
{
    public class Courses
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public CourseLevel Level { get; set; }

        public bool IsPublished { get; set; }

        public DateTime? PublishedDate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int InstructorId { get; set; }

        public Instructors Instructor { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
    }
    public enum CourseLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }
}


