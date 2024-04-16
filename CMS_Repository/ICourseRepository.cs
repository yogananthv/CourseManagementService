using CMS_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Repository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();

        Task<Course?> GetByIdAsync(int id);

        Task<Course> CreateAsync(Course course);

        Task<Course?> UpdateAsync(int id, Course course);

        Task<Course?> DeleteAsync(int id);
    }
}
