using CMS_DataAccess.Data;
using CMS_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TrainingRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<Training> ITrainingRepository.CreateAsync(Training training)
        {
            throw new NotImplementedException();
        }

        public async Task<Training?> ITrainingRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Training>> ITrainingRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Training?> ITrainingRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Training?> ITrainingRepository.UpdateAsync(int id, Training training)
        {
            throw new NotImplementedException();
        }
    }
}
