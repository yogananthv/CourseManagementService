using CMS_Model.DTO;
using CMS_Model.Models;

namespace CMS_Repository
{
    public interface ITrainingRepository
    {
        Task<List<TrainingDto>> GetAllAsync();

        Task<TrainingDto?> GetByIdAsync(int id);

        Task<TrainingDto> CreateAsync(TrainingDto training);

        Task<TrainingDto?> UpdateAsync(int id, TrainingDto training);

    }
}
