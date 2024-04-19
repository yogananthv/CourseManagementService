using CMS_Model.DTO;
using CMS_Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [HttpPost]
        [Route("CreateTraining")]
        public async Task<IActionResult> CreateTraining([FromBody] TrainingDto trainingDto)
        {
            try
            {
                var result = await trainingRepository.CreateAsync(trainingDto);
                return CreatedAtAction("Training Created", result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<TrainingController>/5
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
