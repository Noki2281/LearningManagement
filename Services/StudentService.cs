using LearningManagement.Interfaces;
using LearningManagement.Models;
using System.Collections.Concurrent;

namespace LearningManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly ConcurrentDictionary<Guid, Student> _students = new();

        public IEnumerable<Student> GetAll() => _students.Values;

        public Student? Get(Guid id) => _students.TryGetValue(id, out var student) ? student : null;

        public Student Add(Student student)
        {
            _students[student.Id] = student;
            return student;
        }
    }

}
