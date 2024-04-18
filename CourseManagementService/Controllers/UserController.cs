using CMS_Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAPIRepository userAPIRepository;
        public UserController(IUserAPIRepository _userAPIRepository) 
        { 
            userAPIRepository = _userAPIRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Route("getuserdetails")]
        public async Task<IActionResult> Getuserdetails(string CompanyName)
        {
            var result = await userAPIRepository.GetAllUserAsync(CompanyName);
            return Ok(result);
        }
               
    }
}
