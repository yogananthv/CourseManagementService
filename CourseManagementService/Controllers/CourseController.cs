using CMS_Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        /// <summary>
        /// To get the active courses 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getcourses")]
        public async Task<IActionResult> GetCourses()
        {
            try
            {
                // Information logged to text file using Serilog
                Log.Logger.Information("Getting Course details");
                var result = await courseRepository.GetAllActiveCoursesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
    }
}
