using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskTracker.Domain;

namespace TaskTracker.Persistence.EntityTypeConfigurations
{
    public class ProjectConfiguration:IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(project => project.Id);
            builder.HasIndex(project => project.Id).IsUnique();
            builder.Property(project => project.ProjectName).HasMaxLength(165);
        }
    }
}
