using CMS_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Repository
{
    public interface ISubscriptionRepository
    {
        Task<List<Subscription>> GetAllAsync();

        Task<Subscription?> GetByIdAsync(int id);

        Task<Subscription> CreateAsync(Subscription sub);

        Task<Subscription?> UpdateAsync(int id, Subscription sub);

        Task<Subscription?> DeleteAsync(int id);
    }
}
