using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WorkoutApp.Models;

namespace WorkoutApp.Data
{
    public class WorkoutContext : DbContext
    {
        public DbSet<Workout> Workout { get; set; }
        public DbSet<Exercise> Exercise { get; set; }

        public DbSet<WorkoutExercise> Workout_Exercise { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        const string connectionString = "Server=studmysql01.fhict.local; Port=3306;Database=dbi515670;User=dbi515670;Password=Tua1X#TbOS;";
        optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
