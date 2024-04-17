using CMS_Model.Models;

namespace CMS_Repository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();

        Task<Course?> GetByIdAsync(int id);

       
    }
}
