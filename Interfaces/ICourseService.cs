using LearningManagement.Models;

namespace LearningManagement.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
        Course? Get(Guid id);
        Course Add(Course course);
        bool Update(Guid id, Course updated);
        bool Delete(Guid id);
    }

}
