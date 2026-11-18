using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_91_EF03.Models
{
    public  class Instructors
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }

        public string? ShortBio { get; set; }

        public DateTime AddedDate { get; set; }

        public ICollection<Courses> Courses { get; set; } = new HashSet<Courses>();
    }
}
