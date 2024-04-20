using CMS_Model.DTO;

namespace CMS_Repository
{
    public interface ITrainingRepository
    {
        Task<List<TrainingDto>> GetAllAsync();

        Task<TrainingDto> CreateAsync(TrainingDto training);

        Task<TrainingDto?> UpdateAsync(TrainingDto training);

    }
}
