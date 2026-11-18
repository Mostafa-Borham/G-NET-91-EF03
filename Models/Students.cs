using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_91_EF03.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
    }
}
