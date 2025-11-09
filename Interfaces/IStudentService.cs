using LearningManagement.Models;

namespace LearningManagement.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student? Get(Guid id);
        Student Add(Student student);
    }
}
