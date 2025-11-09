using LearningManagement.Dtos;
using LearningManagement.Models;

namespace LearningManagement.Interfaces
{
    public interface IEnrolmentService
    {
        IEnumerable<Enrolment> GetAll();
        Enrolment Add(Enrolment enrolment);
        IEnumerable<CourseEnrolmentReportDto> GetEnrolmentReport(IEnumerable<Course> courses, IEnumerable<Student> students);

    }
}
