using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskTracker.Domain;

namespace TaskTracker.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Configuration that will be used in OnModelCrating method to make it smaller
    /// </summary>
    public class TaskConfiguration: IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.HasKey(task => task.Id);
            builder.HasIndex(task => task.Id).IsUnique();
            builder.Property(task => task.TaskName).HasMaxLength(165);
            builder.Property(task => task.TaskDescription).HasMaxLength(165);
        }
    }
}
