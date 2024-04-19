using CMS_Model.DTO;
using CMS_Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository subscriptionRepository;

        public SubscriptionController(ISubscriptionRepository _subscriptionRepository)
        {
            subscriptionRepository = _subscriptionRepository;
        }

        // GET: api/<SubscriptionController>
        [HttpGet]
        [Route("GetAllSubscriptions")]
        public async Task<IActionResult> GetAllSubscriptions([FromQuery]SubscriptionDtoSearchInput subInput)
        {
            try
            {
                var result = await subscriptionRepository.GetAllSubscriptionsAsync(subInput.PageNumber, subInput.PageSize, subInput.TrainingCode, subInput.TrainingName, subInput.Month);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/<SubscriptionController>
        [HttpGet]
        [Route("GetAllSubscriptionsDetails")]
        public async Task<IActionResult> GetAllSubscriptionsDetails([FromQuery]SubscriptionDtoSearchInput subInput)
        {
            try
            {
                var result = await subscriptionRepository.GetAllSubscriptionsDetailsAsync(subInput.PageNumber, subInput.PageSize, subInput.TrainingCode, subInput.TrainingName, subInput.Month,
                                                                                        subInput.CourseCode, subInput.CourseName, subInput.UserName, subInput.Gender, subInput.Email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<SubscriptionController>
        [HttpPost]
        [Route("CreateSubscription")]
        public async Task<IActionResult> CreateSubscription([FromBody] SubscriptionDto subDto)
        {
            try
            {
                var availability = await subscriptionRepository.CheckSubscription(subDto);
                if (availability)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed)
                    {
                        Content = new StringContent("User already subscribed for training in " + subDto.TrainingObj.Month)
                    };
                    return BadRequest(response);
                }
                var result = await subscriptionRepository.CreateAsync(subDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
