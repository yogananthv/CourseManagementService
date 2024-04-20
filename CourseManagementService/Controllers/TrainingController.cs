using CMS_Model.DTO;
using CMS_Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;

namespace CourseManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepository trainingRepository;

        public TrainingController(ITrainingRepository _trainingRepository)
        {
            trainingRepository = _trainingRepository;
        }
       
        // GET: api/<TrainingController>
        /// <summary>
        /// Get all trainings
        /// </summary>
        /// <returns>List of trainings</returns>
        [HttpGet]
        [Route("GetAllTrainings")]
        public async Task<IActionResult> GetAllTrainings()
        {
            try
            {
                Log.Logger.Information("Getting training details");
                var result = await trainingRepository.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // POST api/<TrainingController>
        /// <summary>
        /// To create training
        /// </summary>
        /// <param name="trainingDto"></param>
        /// <returns>Created training with newly created Id</returns>
        [HttpPost]
        [Route("CreateTraining")]
        public async Task<IActionResult> CreateTraining([FromBody] TrainingDto trainingDto)
        {
            try
            {
                var result = await trainingRepository.CreateAsync(trainingDto);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<TrainingController>
        /// <summary>
        /// Update training
        /// </summary>
        /// <param name="trainingDto"></param>
        /// <returns>Updated training model</returns>
        [HttpPut]
        [Route("UpdateTraining")]
        public async Task<IActionResult> UpdateTraining([FromBody] TrainingDto trainingDto)
        {
            try
            {
                var result = await trainingRepository.UpdateAsync(trainingDto);
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
