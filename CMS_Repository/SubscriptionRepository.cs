using CMS_DataAccess.Data;
using CMS_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SubscriptionRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Subscription> ISubscriptionRepository.CreateAsync(Subscription sub)
        {
            throw new NotImplementedException();
        }

        public async Task<Subscription?> ISubscriptionRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Subscription>> ISubscriptionRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Subscription?> ISubscriptionRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Subscription?> ISubscriptionRepository.UpdateAsync(int id, Subscription sub)
        {
            throw new NotImplementedException();
        }
    }
}
