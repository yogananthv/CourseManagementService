using AutoMapper;
using CMS_Model.DTO;
using CMS_Model.Models;

namespace CMS_Repository.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Training, TrainingDto>().ReverseMap();
            CreateMap<Subscription, SubscriptionDto>().ReverseMap();
        }
    }
}
