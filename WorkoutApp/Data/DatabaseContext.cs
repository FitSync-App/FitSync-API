using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations.Schema;
using Fitsync.Models;

namespace Fitsync.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Workout> Workout { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<WorkoutExercise> Workout_Exercise { get; set; }
        public DbSet<Muscle> Muscle { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<ExerciseMuscle> Exercise_Muscle { get; set; }
        public DbSet<ExerciseEquipment> Exercise_Equipment { get; set; }
        public DbSet<User> User { get; set; }

        private readonly IConfiguration _connectionstring;
        public DatabaseContext(IConfiguration connectionstring)
        {
            _connectionstring = connectionstring;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionstring.GetConnectionString("DatabaseConnection"));
        }



    }
}
