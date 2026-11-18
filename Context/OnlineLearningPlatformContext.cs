using G_NET_91_EF03.Configuration;
using G_NET_91_EF03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_91_EF03.Context
{
    public class OnlineLearningPlatformContext : DbContext
    {
        public OnlineLearningPlatformContext(DbContextOptions<OnlineLearningPlatformContext> options) : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }

        public DbSet<Instructors> Instructors { get; set; }

        public DbSet<Courses> Courses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorsConfiguration());
            modelBuilder.ApplyConfiguration(new CoursesConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
        }


    }
}
