using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_91_EF03.Models
{
    public class Enrollment
    {

        public DateTime EnrollmentDate { get; set; }

        public decimal PercentageProgress { get; set; }

        public Status EStatus { get; set; }

        public decimal? FinalGrade { get; set; }
        public int StudentId { get; set; }

        public Students Student { get; set; }

        public int CourseId { get; set; }

        public Courses Course { get; set; }
    }
    public enum Status
    {
        Active,
        Completed,
        Dropped
    }
}
