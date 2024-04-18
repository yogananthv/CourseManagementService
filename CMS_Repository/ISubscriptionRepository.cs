using CMS_Model.DTO;
using CMS_Model.Models;

namespace CMS_Repository
{
    public interface ISubscriptionRepository
    {
        Task<List<SubscriptionDto>> GetAllSubscriptionsAsync(int pageNumber = 1, int pageSize = 100, string trainingCode = "", string trainingName = "", string month = "");

        Task<List<SubscriptionDto>> GetAllSubscriptionsDetailsAsync(int pageNumber, int pageSize, string trainingCode = "", string trainingName = "", string month = "",
                                                                    string courseCode = "", string courseName = "", string userName = "", string gender = "", string email = "");

        Task<SubscriptionDto> CreateAsync(SubscriptionDto sub);

        Task<bool> CheckSubscription(SubscriptionDto subscriptionDto);

    }
}
