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
            string connectionString = "Server=localhost;Database=test2;Uid=root;";
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
