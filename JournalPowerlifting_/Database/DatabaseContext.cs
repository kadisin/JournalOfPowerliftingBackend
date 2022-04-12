using Microsoft.EntityFrameworkCore;

namespace JournalPowerlifting_.Database
{
    public class DatabaseContext : DbContext
    {

        public DbSet<AccountDB> Account { get; set; }
        public DbSet<TrainingDayDB> TrainingDay { get; set; }
        public DbSet<ExerciseDB> Exercise { get; set; }
        public DbSet<PlanSetDB> PlanSet { get; set; }
        public DbSet<TrainingPlanDB> TrainingPlan { get; set; }
        public DbSet<TrainingDB> Training { get; set; }
        public DbSet<RealTrainingDB> RealTraining { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }




    }
}
