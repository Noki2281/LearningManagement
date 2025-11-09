using LearningManagement.Interfaces;
using LearningManagement.Models;

namespace LearningManagement.Services
{
    public static class DataSeeder
    {
        public static void Seed(ICourseService courseService, IStudentService studentService)
        {
            // Seed 3 demo courses
            var courses = new[]
            {
                new Course { Title = "Mathematics 101", Description = "Introduction to basic math principles." },
                new Course { Title = "History 201", Description = "Overview of world history and civilizations." },
                new Course { Title = "Programming 301", Description = "Learn C# and .NET fundamentals." }
            };
            foreach (var c in courses)
                courseService.Add(c);

            // Seed 10 demo students
            var students = Enumerable.Range(1, 10)
                .Select(i => new Student { Name = $"Student {i}" });
            foreach (var s in students)
                studentService.Add(s);
        }
    }

}
