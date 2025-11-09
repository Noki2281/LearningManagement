using LearningManagement.Dtos;
using LearningManagement.Interfaces;
using LearningManagement.Models;
using System.Collections.Concurrent;

namespace LearningManagement.Services
{
    public class EnrolmentService : IEnrolmentService
    {
        private readonly ConcurrentBag<Enrolment> _enrolments = new();
        private readonly ICourseService _courseService;

        public EnrolmentService(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IEnumerable<Enrolment> GetAll() => _enrolments;

        public Enrolment Add(Enrolment enrolment)
        {
            _enrolments.Add(enrolment);
            return enrolment;
        }

        // 🆕 Build a report of courses with enrolled students
        public IEnumerable<CourseEnrolmentReportDto> GetEnrolmentReport(
            IEnumerable<Course> courses, IEnumerable<Student> students)
        {
            var report = new List<CourseEnrolmentReportDto>();

            foreach (var course in courses)
            {
                var enrolledStudentIds = _enrolments
                    .Where(e => e.CourseId == course.Id)
                    .Select(e => e.StudentId)
                    .ToList();

                var enrolledStudents = students
                    .Where(s => enrolledStudentIds.Contains(s.Id))
                    .Select(s => new StudentDto
                    {
                        Id = s.Id,
                        Name = s.Name
                    })
                    .ToList();

                report.Add(new CourseEnrolmentReportDto
                {
                    CourseId = course.Id,
                    CourseTitle = course.Title,
                    CourseDescription = course.Description,
                    EnrolledStudents = enrolledStudents
                });
            }

            return report;
        }
    }

}