using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutApp.Models;

namespace WorkoutApp.Data
{
    public class WorkoutContext : DbContext
    {
        public DbSet<Workout> Workout { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<WorkoutExercise> Workout_Exercise { get; set; }
        public DbSet<User> User { get; set; }

        private readonly IConfiguration _connectionstring;

        public WorkoutContext(IConfiguration connectionstring)
        {
            _connectionstring = connectionstring;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionstring.GetConnectionString("DatabaseConnection"));
        }
    }
}
