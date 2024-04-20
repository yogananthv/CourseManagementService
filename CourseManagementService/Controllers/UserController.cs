using CMS_Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        /// <summary>
        /// Get the user details for the company using third party API
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns>User details</returns>
        [HttpGet]
        [Route("getuserdetails")]
        public async Task<IActionResult> Getuserdetails(string CompanyName)
        {
            try
            {
                Log.Logger.Information("Getting User details");
                var result = await userAPIRepository.GetAllUserAsync(CompanyName);
                return Ok(result);
            }
            catch(Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
               
    }
}
