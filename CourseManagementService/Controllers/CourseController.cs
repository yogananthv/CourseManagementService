using CMS_Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;
        public CourseController(ICourseRepository _courseRepository)
        {
            courseRepository = _courseRepository;
        }

        // GET: api/<courseController>
        [HttpGet]
        [Route("getcourses")]
        public async Task<IActionResult> GetCourses()
        {
            var result = await courseRepository.GetAllActiveCoursesAsync();
            return Ok(result);
        }
    }
}
