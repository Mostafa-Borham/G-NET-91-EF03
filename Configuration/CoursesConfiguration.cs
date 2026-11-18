using G_NET_91_EF03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_91_EF03.Configuration
{
    public class CoursesConfiguration : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Description).HasMaxLength(1000);
            builder.Property(c => c.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.Level).IsRequired();
            builder.Property(c => c.IsPublished).IsRequired();
            builder.Property(c => c.PublishedDate);
            builder.HasOne(c => c.Category)
                .WithMany(cat => cat.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new Courses
                {
                    Id = 1,
                    Title = "ASP.NET Core Advanced",
                    Description = "Advanced backend development",
                    Price = 1200m,
                    Level = CourseLevel.Advanced,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 5, 1),
                    InstructorId = 1,
                    CategoryId = 3
                },
                new Courses
                {
                    Id = 2,
                    Title = "Backend Fundamentals",
                    Description = "Backend basics",
                    Price = 800m,
                    Level = CourseLevel.Intermediate,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 6, 1),
                    InstructorId = 1,
                    CategoryId = 2
                },
                new Courses
                {
                    Id = 3,
                    Title = "HTML and CSS",
                    Description = "Frontend basics",
                    Price = 500m,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 7, 1),
                    InstructorId = 2,
                    CategoryId = 4
                },
                new Courses
                {
                    Id = 4,
                    Title = "SQL Server",
                    Description = "Database fundamentals",
                    Price = 700m,
                    Level = CourseLevel.Intermediate,
                    IsPublished = false,
                    PublishedDate = null,
                    InstructorId = 2,
                    CategoryId = 5
                },
                new Courses
                {
                    Id = 5,
                    Title = "ASP.NET Introduction",
                    Description = "Introduction to ASP.NET",
                    Price = 600m,
                    Level = CourseLevel.Beginner,
                    IsPublished = false,
                    PublishedDate = null,
                    InstructorId = 3,
                    CategoryId = 3
                },
                new Courses
                {
                    Id = 6,
                    Title = "Programming Concepts",
                    Description = "Advanced programming concepts",
                    Price = 900m,
                    Level = CourseLevel.Advanced,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 8, 1),
                    InstructorId = 3,
                    CategoryId = 1
                }
            );
        }
    }
}
