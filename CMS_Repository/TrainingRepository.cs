using AutoMapper;
using CMS_DataAccess.Data;
using CMS_Model.DTO;
using CMS_Model.Models;
using Microsoft.EntityFrameworkCore;
using CMS_Repository.Mappings;

namespace CMS_Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public TrainingRepository(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        async Task<TrainingDto> ITrainingRepository.CreateAsync(TrainingDto trainingDto)
        {
            var training = mapper.Map<Training>(trainingDto);
            await dbContext.Trainings.AddAsync(training);
            await dbContext.SaveChangesAsync();
            return trainingDto;
        }

        async Task<List<TrainingDto>> ITrainingRepository.GetAllAsync()
        {
            var item = await (
                        from t in dbContext.Trainings
                        join c in dbContext.Courses on t.CourseId equals c.Id
                        select new TrainingDto
                        {
                            Id = t.Id,
                            Code = t.Code,
                            CourseObj = new CourseDto
                            {
                                Code = c.Code,
                                Description = c.Description,
                                Name = c.Name,
                                Title = c.Title
                            },
                            CourseId = c.Id,
                            Month = t.Month,
                            Name = t.Name,
                            Status = t.Status
                        }).ToListAsync();
            return item;
        }

        //async Task<TrainingDto?> ITrainingRepository.GetByIdAsync(int id)
        //{
        //    var item = await (
        //               from t in dbContext.Trainings
        //               join c in dbContext.Courses on t.CourseId equals c.Id
        //               where t.Id == id 
        //               select new TrainingDto
        //               {
        //                   Id = t.Id,
        //                   Code = t.Code,
        //                   CourseObj = new CourseDto
        //                   {
        //                       Code = c.Code,
        //                       Description = c.Description,
        //                       Name = c.Name,
        //                       Title = c.Title
        //                   },
        //                   CourseId = c.Id,
        //                   Month = t.Month,
        //                   Name = t.Name,
        //                   Status = t.Status
        //               }).FirstOrDefaultAsync();
        //    return item;
        //}

        async Task<TrainingDto?> ITrainingRepository.UpdateAsync(TrainingDto training)
        {
            var existingTraining = await dbContext.Trainings.FirstOrDefaultAsync(x => x.Id == training.Id);

            if (existingTraining == null)
            {
                return null;
            }

            existingTraining.Code = training.Code;
            existingTraining.Name = training.Name;
            existingTraining.CourseId = training.CourseId;
            existingTraining.Month = training.Month;
            existingTraining.Status = training.Status;

            await dbContext.SaveChangesAsync();
            return training;
        }
    }
}
