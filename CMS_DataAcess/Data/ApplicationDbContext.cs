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

        //public DbSet<User> Users { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasKey(user => new { user.UserId, user.Company });
        //}
    }
}
