using CMS_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS_DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

    }
}
