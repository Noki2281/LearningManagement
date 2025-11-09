namespace LearningManagement.Models
{
    public class Enrolment
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime EnrolledOn { get; set; } = DateTime.UtcNow;
    }

}
