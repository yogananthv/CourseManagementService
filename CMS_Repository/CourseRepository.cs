using CMS_DataAccess.Data;
using CMS_Model.Models;

namespace CMS_Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CourseRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        
        Task<List<Course>> ICourseRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Course?> ICourseRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
