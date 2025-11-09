using LearningManagement.Interfaces;
using LearningManagement.Models;
using LearningManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrolmentsController : ControllerBase
    {
        private readonly IEnrolmentService _enrolmentService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public EnrolmentsController(
            IEnrolmentService enrolmentService,
            ICourseService courseService,
            IStudentService studentService)
        {
            _enrolmentService = enrolmentService;
            _courseService = courseService;
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_enrolmentService.GetAll());

        [HttpPost]
        public IActionResult Add([FromBody] Enrolment enrolment)
        {
            var result = _enrolmentService.Add(enrolment);
            return Ok(result);
        }

        [HttpGet("report")]
        public IActionResult GetReport()
        {
            var report = _enrolmentService.GetEnrolmentReport(
            _courseService.GetAll(),
                _studentService.GetAll());

            return Ok(report);
        }
    }
}
