using LearningManagement.Models;
using LearningManagement.Services;
using Xunit;

namespace LearningManagement.Tests
{
    public class CourseServiceTests
    {
        [Fact]
        public void AddCourse_ShouldStoreAndRetrieveCourse()
        {
            var service = new CourseService();
            var course = new Course { Title = "Math 101" };

            service.Add(course);
            var retrieved = service.Get(course.Id);

            Assert.NotNull(retrieved);
            Assert.Equal("Math 101", retrieved!.Title);
        }
    }
}
