using CMS_Model.DTO;
using CMS_Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;

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
        /// <summary>
        /// Get all subscriptions for the search & Pagination inputs
        /// </summary>
        /// <param name="subInput"></param>
        /// <returns>List of subscriptions</returns>
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
        /// <summary>
        /// Get all subscriptions details for the search & Pagination inputs
        /// </summary>
        /// <param name="subInput"></param>
        /// <returns>List of subscription details</returns>
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
        /// <summary>
        /// Create subscription with the given input
        /// </summary>
        /// <param name="subDto"></param>
        /// <returns>Created subcription</returns>
        [HttpPost]
        [Route("CreateSubscription")]
        public async Task<IActionResult> CreateSubscription([FromBody] SubscriptionDto subDto)
        {
            try
            {
                // Validate whether user already subscribed to any trainings in the same month.
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
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
