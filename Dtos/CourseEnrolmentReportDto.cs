using LearningManagement.Interfaces;

namespace LearningManagement.Dtos
{
    public class CourseEnrolmentReportDto
    {
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public string CourseDescription { get; set; } = string.Empty;
        public List<StudentDto> EnrolledStudents { get; set; } = new();
    }

}
