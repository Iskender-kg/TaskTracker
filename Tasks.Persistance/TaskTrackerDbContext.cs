using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain;
using TaskTracker.Application.Interfaces;
using TaskTracker.Persistence.EntityTypeConfigurations;
namespace TaskTracker.Persistence
{
    /// <summary>
    /// Class that represents DbContext
    /// </summary>
    public class TaskTrackerDbContext: DbContext, ITaskTrackerDbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TaskConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
