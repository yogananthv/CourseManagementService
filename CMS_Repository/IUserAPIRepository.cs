using CMS_Model.DTO;

namespace CMS_Repository
{
    public interface IUserAPIRepository
    {
        Task<List<UserDto>> GetAllUserAsync(string companyName);

    }
}
