using CMS_DataAccess.Data;
using CMS_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CourseRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<Course> ICourseRepository.CreateAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<Course?> ICourseRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> ICourseRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Course?> ICourseRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Course?> ICourseRepository.UpdateAsync(int id, Course course)
        {
            throw new NotImplementedException();
        }
    }
}
