using G_NET_91_EF03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_91_EF03.Configuration
{
    public class InstructorsConfiguration : IEntityTypeConfiguration<Instructors>
    {
        public void Configure(EntityTypeBuilder<Instructors> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.FullName).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Email).IsRequired().HasMaxLength(100);
            builder.Property(i => i.ShortBio).HasMaxLength(500);
            builder.Property(i => i.AddedDate).IsRequired();
            builder.HasMany(i => i.Courses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new Instructors
                {
                    Id = 1,
                    FullName = "Ahmed Ali",
                    Email = "ahmed@test.com",
                    ShortBio = "Backend Developer",
                    AddedDate = new DateTime(2025, 1, 1)
                },
                new Instructors
                {
                    Id = 2,
                    FullName = "Mohamed Samir",
                    Email = "mohamed@test.com",
                    ShortBio = "Frontend Developer",
                    AddedDate = new DateTime(2025, 2, 1)
                },
                new Instructors
                {
                    Id = 3,
                    FullName = "Sara Hassan",
                    Email = "sara@test.com",
                    ShortBio = "Software Engineer",
                    AddedDate = new DateTime(2025, 3, 1)
                }
            );
        }
    }
}
