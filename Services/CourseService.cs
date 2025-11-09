using LearningManagement.Interfaces;
using LearningManagement.Models;
using System.Collections.Concurrent;

namespace LearningManagement.Services
{
    public class CourseService : ICourseService
    {
        private readonly ConcurrentDictionary<Guid, Course> _courses = new();

        public IEnumerable<Course> GetAll() => _courses.Values;

        public Course? Get(Guid id) => _courses.TryGetValue(id, out var course) ? course : null;

        public Course Add(Course course)
        {
            _courses[course.Id] = course;
            return course;
        }

        public bool Update(Guid id, Course updated)
        {
            if (!_courses.ContainsKey(id)) return false;
            _courses[id] = updated;
            return true;
        }

        public bool Delete(Guid id) => _courses.TryRemove(id, out _);
    }

}
