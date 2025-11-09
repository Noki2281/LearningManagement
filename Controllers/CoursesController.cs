using LearningManagement.Interfaces;
using LearningManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;

        public CoursesController(ICourseService service) => _service = service;

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) =>
            _service.Get(id) is { } course ? Ok(course) : NotFound();

        [HttpPost]
        public IActionResult Add([FromBody] Course course) =>
            Ok(_service.Add(course));

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Course updated) =>
            _service.Update(id, updated) ? Ok(updated) : NotFound();

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) =>
            _service.Delete(id) ? NoContent() : NotFound();
    }
}
