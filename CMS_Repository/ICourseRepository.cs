using CMS_Model.DTO;

namespace CMS_Repository
{
    public interface ICourseRepository
    {
        Task<List<CourseDto>> GetAllActiveCoursesAsync();
    }
}
