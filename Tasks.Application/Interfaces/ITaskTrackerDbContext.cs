using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces
{
    public interface ITaskTrackerDbContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectTask> Tasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
