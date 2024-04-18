using CMS_Model.DTO;
using CMS_Model.Models;

namespace CMS_Repository
{
    public interface ICourseRepository
    {
        Task<List<CourseDto>> GetAllActiveCoursesAsync();
    }
}
