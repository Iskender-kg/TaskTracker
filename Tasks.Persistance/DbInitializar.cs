using TaskTracker.Persistence;

namespace TaskTracker.Persistence
{
    public class DbInitializar
    {
        /// <summary>
        /// Method that initializes Db in case if there is no Db 
        /// </summary>
        public static void Initialize(TaskTrackerDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
