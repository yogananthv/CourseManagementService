using AutoMapper;
using CMS_DataAccess.Data;
using CMS_Model.DTO;
using CMS_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS_Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public SubscriptionRepository(ApplicationDbContext _dbContext, IMapper mapper)
        {
            dbContext = _dbContext;
            this.mapper = mapper;
        }

        async Task<SubscriptionDto> ISubscriptionRepository.CreateAsync(SubscriptionDto subscriptionDto)
        {
            var subscription = mapper.Map<Subscription>(subscriptionDto);
            await dbContext.Subscriptions.AddAsync(subscription);
            await dbContext.SaveChangesAsync();
            return subscriptionDto;
        }

        async Task<bool> ISubscriptionRepository.CheckSubscription(SubscriptionDto subscriptionDto)
        {
            var existingsub = await dbContext.Subscriptions.FirstOrDefaultAsync(x => x.UserId == subscriptionDto.UserId && x.Training.Month.ToLower() == subscriptionDto.TrainingObj.Month.ToLower());

            if (existingsub != null && existingsub.UserId == subscriptionDto.UserId)
            {
                return true;
            }
            return false;
        }

        async Task<List<SubscriptionDto>> ISubscriptionRepository.GetAllSubscriptionsAsync(int pageNumber = 1, int pageSize = 100, string trainingCode = "", string trainingName = "", string month = "")
        {
            trainingCode = string.IsNullOrEmpty(trainingCode) ? "" : trainingCode;
            trainingName = string.IsNullOrEmpty(trainingName) ? "" : trainingName;
            month = string.IsNullOrEmpty(month) ? "" : month;

            var item = await(
                        from s in dbContext.Subscriptions
                        join t in dbContext.Trainings on s.TrainingId equals t.Id
                        where (trainingCode == "" || t.Code.ToLower() == trainingCode.ToLower()) && (trainingName == "" || t.Name.ToLower() == trainingName.ToLower()) && (month == "" || t.Month.ToLower() == month.ToLower())
                        orderby (s.Id)
                        select new SubscriptionDto
                        {
                            Id = s.Id,
                            TrainingObj = new TrainingDto
                            {
                                Code = t.Code,
                                Name = t.Name,
                                Month = t.Month
                            },
                            Status = s.Status
                        }).Skip((pageNumber-1) * pageSize).Take(pageSize).ToListAsync();


            return item;
        }

        async Task<List<SubscriptionDto>> ISubscriptionRepository.GetAllSubscriptionsDetailsAsync(int pageNumber, int pageSize, string trainingCode = "", string trainingName = "", string month = "",
                                                                                                  string courseCode = "", string courseName = "", string userName = "", string gender = "",string email = "")
        {
            trainingCode = string.IsNullOrEmpty(trainingCode) ? "" : trainingCode;
            trainingName = string.IsNullOrEmpty(trainingName) ? "" : trainingName;
            month = string.IsNullOrEmpty(month) ? "" : month;
            courseCode = string.IsNullOrEmpty(courseCode) ? "" : courseCode;
            courseName = string.IsNullOrEmpty(courseName) ? "" : courseName;
            userName = string.IsNullOrEmpty(userName) ? "" : userName;
            gender = string.IsNullOrEmpty(gender) ? "" : gender;
            email = string.IsNullOrEmpty(email) ? "" : email;

            var item = await (
                        from s in dbContext.Subscriptions
                        join t in dbContext.Trainings on s.TrainingId equals t.Id 
                        join c in dbContext.Courses on t.CourseId equals c.Id
                        where (trainingCode == "" || t.Code.ToLower() == trainingCode.ToLower()) && (trainingName == "" || t.Name.ToLower() == trainingName.ToLower()) && (month == "" || t.Month.ToLower() == month.ToLower())
                               && (courseCode == "" || c.Code.ToLower() == courseCode.ToLower()) && (courseName == "" || c.Name.ToLower() == courseName.ToLower()) && (userName == "" || s.UserName.ToLower() == userName.ToLower())
                               && (gender == "" || s.Gender.ToLower() == gender.ToLower()) && (email == "" || s.Email.ToLower() == email.ToLower())
                        select new SubscriptionDto
                        {
                            Id = s.Id,
                            TrainingObj = new TrainingDto
                            {
                                Code = t.Code,
                                Name = t.Name,
                                Month = t.Month,
                                CourseObj = new CourseDto
                                {
                                    Code = c.Code,
                                    Name = c.Name
                                }
                            },
                            UserId = s.UserId,
                            Email = s.Email,
                            Gender = s.Gender,
                            Status = s.Status
                        }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return item;
        }
    }
}
