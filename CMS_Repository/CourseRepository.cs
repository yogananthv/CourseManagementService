using CMS_DataAccess.Data;
using CMS_Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace CMS_Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CourseRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        async Task<List<CourseDto>> ICourseRepository.GetAllActiveCoursesAsync()
        {
            var item = await (
                        from c in dbContext.Courses 
                        where c.Status.ToLower() == "active" // get only the active courses
                        select new CourseDto
                        {
                           Code = c.Code,
                           Description = c.Description,
                           Name = c.Name,
                           Status = c.Status,
                           Id = c.Id,
                           Title = c.Title
                        }).ToListAsync();
            return item;
        }
    }
}
