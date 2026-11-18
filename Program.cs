using G_NET_91_EF03.Context;
using G_NET_91_EF03.Models;
using Microsoft.EntityFrameworkCore;

namespace G_NET_91_EF03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<OnlineLearningPlatformContext>()
                .UseSqlServer(
                    "Server=.;Database=OnlineLearningPlatformDB;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            using var context = new OnlineLearningPlatformContext(options);

            #region Data Seeding
            // Apply pending migrations
            //context.Database.Migrate();

            //if (!context.Students.Any())
            //{
            //    var students = new List<Students>
            //    {
            //        new Students
            //        {
            //            FullName = "Omar Ahmed",
            //            Email = "omar@test.com",
            //            DateOfBirth = new DateTime(2003, 5, 10)
            //        },
            //        new Students
            //        {
            //            FullName = "Ali Hassan",
            //            Email = "ali@test.com",
            //            DateOfBirth = new DateTime(2002, 8, 15)
            //        },
            //        new Students
            //        {
            //            FullName = "Mona Mohamed",
            //            Email = "mona@test.com",
            //            DateOfBirth = new DateTime(2004, 2, 20)
            //        },
            //        new Students
            //        {
            //            FullName = "Sara Ahmed",
            //            Email = "sara2@test.com",
            //            DateOfBirth = new DateTime(2003, 11, 5)
            //        },
            //        new Students
            //        {
            //            FullName = "Youssef Ali",
            //            Email = "youssef@test.com",
            //            DateOfBirth = new DateTime(2002, 3, 12)
            //        }
            //    };

            //    context.Students.AddRange(students);
            //    context.SaveChanges();
            //}

            //// Seed Enrollments
            //if (!context.Enrollments.Any())
            //{
            //    var enrollments = new List<Enrollment>
            //    {
            //        // Active
            //        new Enrollment
            //        {
            //            StudentId = 1,
            //            CourseId = 1,
            //            EnrollmentDate = new DateTime(2025, 9, 1),
            //            PercentageProgress = 40,
            //            EStatus = Status.Active,
            //            FinalGrade = null
            //        },

            //        new Enrollment
            //        {
            //            StudentId = 2,
            //            CourseId = 2,
            //            EnrollmentDate = new DateTime(2025, 9, 2),
            //            PercentageProgress = 60,
            //            EStatus = Status.Active,
            //            FinalGrade = null
            //        },

            //        new Enrollment
            //        {
            //            StudentId = 3,
            //            CourseId = 3,
            //            EnrollmentDate = new DateTime(2025, 9, 3),
            //            PercentageProgress = 20,
            //            EStatus = Status.Active,
            //            FinalGrade = null
            //        },

            //        // Completed
            //        new Enrollment
            //        {
            //            StudentId = 1,
            //            CourseId = 2,
            //            EnrollmentDate = new DateTime(2025, 8, 1),
            //            PercentageProgress = 100,
            //            EStatus = Status.Completed,
            //            FinalGrade = 95
            //        },

            //        new Enrollment
            //        {
            //            StudentId = 4,
            //            CourseId = 1,
            //            EnrollmentDate = new DateTime(2025, 8, 5),
            //            PercentageProgress = 100,
            //            EStatus = Status.Completed,
            //            FinalGrade = 88
            //        },

            //        new Enrollment
            //        {
            //            StudentId = 5,
            //            CourseId = 6,
            //            EnrollmentDate = new DateTime(2025, 8, 10),
            //            PercentageProgress = 100,
            //            EStatus = Status.Completed,
            //            FinalGrade = 92
            //        },

            //        // Dropped
            //        new Enrollment
            //        {
            //            StudentId = 2,
            //            CourseId = 3,
            //            EnrollmentDate = new DateTime(2025, 7, 1),
            //            PercentageProgress = 30,
            //            EStatus = Status.Dropped,
            //            FinalGrade = null
            //        },

            //        new Enrollment
            //        {
            //            StudentId = 3,
            //            CourseId = 6,
            //            EnrollmentDate = new DateTime(2025, 7, 5),
            //            PercentageProgress = 50,
            //            EStatus = Status.Dropped,
            //            FinalGrade = null
            //        }
            //    };

            //    context.Enrollments.AddRange(enrollments);
            //    context.SaveChanges();
            //}

            //Console.WriteLine("Database seeded successfully!");

            #endregion

            #region Operations
            // Create Operations

            //AddInstructor(context);

            //AddCourse(context);

            //AddStudents(context);

            //EnrollStudent(context);


            // Read Operations

            //FindCourse(context);

            //FilterCourses(context, 100, 500);

            //DisplaySubCategories(context, 1);


            // Update Operations

            //ChangeCoursePrice(context, 1, 1500);

            //UpdateEnrollmentProgress(context, 1, 1, 100);

            //PublishCourse(context, 4);

            // Delete Operations

            // Delete Operations

            //UnenrollStudent(context, 1, 1);

            //SafeDeleteCategory(context, 1);

            //DeleteCourseWithEnrollments(context, 1);
            #endregion


        }
        #region Create
        //Add a new instructor
        static void AddInstructor(OnlineLearningPlatformContext context)
        {
            var instructor = new Instructors
            {
                FullName = "Mahmoud Ibrahim",
                Email = "mahmoud@test.com",
                ShortBio = "Backend Developer",
                AddedDate = DateTime.Now
            };

            context.Instructors.Add(instructor);
            context.SaveChanges();

            Console.WriteLine($"Instructor added successfully. ID: {instructor.Id}");
        }

        //Add a new course
        static void AddCourse(OnlineLearningPlatformContext context)
        {
            int instructorId = 1;
            int categoryId = 3;

            bool instructorExists = context.Instructors
                .Any(i => i.Id == instructorId);

            bool categoryExists = context.Categories
                .Any(c => c.Id == categoryId);

            if (!instructorExists)
            {
                Console.WriteLine("Instructor not found!");
                return;
            }

            if (!categoryExists)
            {
                Console.WriteLine("Category not found!");
                return;
            }

            var course = new Courses
            {
                Title = "C# Advanced",
                Description = "Advanced C# Course",
                Price = 1000,
                Level = CourseLevel.Advanced,
                IsPublished = false,
                PublishedDate = null,
                InstructorId = instructorId,
                CategoryId = categoryId
            };

            context.Courses.Add(course);
            context.SaveChanges();

            Console.WriteLine($"Course added successfully. ID: {course.Id}");
        }


        //Add a new Students
        static void AddStudents(OnlineLearningPlatformContext context)
        {
            var students = new List<Students>
            {
                new Students
                {
                    FullName = "Student One",
                    Email = "student1@test.com",
                    DateOfBirth = new DateTime(2003, 1, 1)
                },

                new Students
                {
                    FullName = "Student Two",
                    Email = "student2@test.com",
                    DateOfBirth = new DateTime(2003, 2, 1)
                },

                new Students
                {
                    FullName = "Student Three",
                    Email = "student3@test.com",
                    DateOfBirth = new DateTime(2003, 3, 1)
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            foreach (var student in students)
            {
                Console.WriteLine($"{student.FullName} - ID: {student.Id}");
            }
        }

        //Add a new Enrollment
        static void EnrollStudent(OnlineLearningPlatformContext context)
        {
            int studentId = 1;
            int courseId = 1;

            var studentExists = context.Students
                .Any(s => s.Id == studentId);

            var course = context.Courses
                .FirstOrDefault(c => c.Id == courseId);

            if (!studentExists)
            {
                Console.WriteLine("Student not found!");
                return;
            }

            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }

            if (!course.IsPublished)
            {
                Console.WriteLine("Cannot enroll. Course is not published!");
                return;
            }

            bool alreadyEnrolled = context.Enrollments
                .Any(e => e.StudentId == studentId &&
                            e.CourseId == courseId);

            if (alreadyEnrolled)
            {
                Console.WriteLine("Student is already enrolled!");
                return;
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now,
                PercentageProgress = 0,
                EStatus = Status.Active,
                FinalGrade = null
            };

            context.Enrollments.Add(enrollment);
            context.SaveChanges();

            Console.WriteLine("Student enrolled successfully!");
        }

        #endregion

        #region Read
        //Find a course by Id or Title
        static void FindCourse(OnlineLearningPlatformContext context)
        {
            // Find by Id
            Console.WriteLine("Search Course By ID:");

            var courseById = context.Courses.Find(1);

            if (courseById != null)
            {
                Console.WriteLine($"ID: {courseById.Id}");
                Console.WriteLine($"Title: {courseById.Title}");
            }
            else
            {
                Console.WriteLine("Course not found");
            }

            // Find by Title
            Console.WriteLine("\nSearch Course By Title:");

            var courseByTitle = context.Courses
                .FirstOrDefault(c => c.Title == "ASP.NET Core Advanced");

            if (courseByTitle != null)
            {
                Console.WriteLine($"ID: {courseByTitle.Id}");
                Console.WriteLine($"Title: {courseByTitle.Title}");
            }
            else
            {
                Console.WriteLine("Course not found");
            }
        }

        //Filter courses by price range
        static void FilterCourses(
        OnlineLearningPlatformContext context, decimal minPrice, decimal maxPrice)
        {
            var courses = context.Courses
                .Where(c => c.Price >= minPrice && c.Price <= maxPrice)
                .OrderByDescending(c => c.Price)
                .Select(c => new
                {
                    c.Title,
                    c.Level,
                    c.Price
                })
                .ToList();

            Console.WriteLine("\nCourses Between Prices:");

            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found");
                return;
            }

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"Title: {course.Title}, Level: {course.Level}, Price: {course.Price}");
            }
        }

        //Display sub-categories and top-level categories
        static void DisplaySubCategories(OnlineLearningPlatformContext context,int categoryId)
        {
            // Direct Sub-Categories
            Console.WriteLine("\nSub-Categories:");

            var subCategories = context.Categories
                .Where(c => c.ParentCategoryId == categoryId)
                .ToList();

            if (subCategories.Count == 0)
            {
                Console.WriteLine("No sub-categories found");
            }
            else
            {
                foreach (var category in subCategories)
                {
                    Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
                }
            }

            // Top-Level Categories
            Console.WriteLine("\nTop-Level Categories:");

            var topCategories = context.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToList();

            foreach (var category in topCategories)
            {
                Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
            }
        }
        #endregion

        #region Update
        //Change the price of a course
        static void ChangeCoursePrice( OnlineLearningPlatformContext context,int courseId,decimal newPrice)
        {
            var course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found");
                return;
            }

            course.Price = newPrice;

            context.SaveChanges();

            Console.WriteLine("Course price updated successfully");
        }

        static void UpdateEnrollmentProgress(OnlineLearningPlatformContext context,int studentId,int courseId,decimal newProgress)
        {
            // Validate Progress
            if (newProgress < 0 || newProgress > 100)
            {
                Console.WriteLine("Progress must be between 0 and 100");
                return;
            }

            // Find Enrollment using Composite Key
            var enrollment = context.Enrollments.Find(studentId, courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found");
                return;
            }

            // Update Progress
            enrollment.PercentageProgress = newProgress;

            // If Progress = 100, set Status to Completed
            if (newProgress == 100)
            {
                enrollment.EStatus = Status.Completed;
            }

            context.SaveChanges();

            Console.WriteLine("Enrollment progress updated successfully");
        }

        static void PublishCourse(OnlineLearningPlatformContext context,int courseId)
        {
            var course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found");
                return;
            }

            course.IsPublished = true;
            course.PublishedDate = DateTime.Now;

            context.SaveChanges();

            Console.WriteLine("Course published successfully");
        }
        #endregion

        #region Delete
        static void UnenrollStudent(OnlineLearningPlatformContext context,int studentId,int courseId)
        {
            var enrollment = context.Enrollments.Find(studentId, courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found");
                return;
            }

            context.Enrollments.Remove(enrollment);

            context.SaveChanges();

            Console.WriteLine("Student unenrolled successfully");
        }

        static void SafeDeleteCategory(OnlineLearningPlatformContext context,int categoryId)
        {
            var category = context.Categories.Find(categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found");
                return;
            }

            bool hasSubCategories = context.Categories
                .Any(c => c.ParentCategoryId == categoryId);

            if (hasSubCategories)
            {
                Console.WriteLine("Cannot delete category because it has sub-categories");
                return;
            }

            bool hasCourses = context.Courses
                .Any(c => c.CategoryId == categoryId);

            if (hasCourses)
            {
                Console.WriteLine("Cannot delete category because it has courses");
                return;
            }

            context.Categories.Remove(category);

            context.SaveChanges();

            Console.WriteLine("Category deleted successfully");
        }

        static void DeleteCourseWithEnrollments(OnlineLearningPlatformContext context,int courseId)
        {
            var course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found");
                return;
            }

            int enrollmentsBefore = context.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine($"Enrollments Before Delete: {enrollmentsBefore}");

            context.Courses.Remove(course);

            context.SaveChanges();

            int enrollmentsAfter = context.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine($"Enrollments After Delete: {enrollmentsAfter}");

            Console.WriteLine("Course deleted successfully");
        }
        #endregion


    }
}