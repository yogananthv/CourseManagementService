using CMS_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Repository
{
    public interface ITrainingRepository
    {
        Task<List<Training>> GetAllAsync();

        Task<Training?> GetByIdAsync(int id);

        Task<Training> CreateAsync(Training training);

        Task<Training?> UpdateAsync(int id, Training training);

        Task<Training?> DeleteAsync(int id);
    }
}
