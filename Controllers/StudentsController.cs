using LearningManagement.Interfaces;
using LearningManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpPost]
        public IActionResult Add([FromBody] Student student)
        {
            var added = _service.Add(student);
            return Ok(added);
        }
    }
}
