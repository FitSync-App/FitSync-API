using Fitsync.Controllers;
using Fitsync.Data;
using Fitsync.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace FitSync_Tests
{
    public class Workout_Tests
    {
        private DatabaseContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new DatabaseContext(options);
        }

        [Fact]
        public async Task CheckIfWorkoutDataIsCorrectlyReceived()
        {
            using (var context = CreateInMemoryContext())
            {
                context.Add(new Workout { Name = "Test1", Description = "Test1", Duration = "Test1", Difficulty = "Test", UserId = "1" });
                context.Add(new Workout { Name = "Test2", Description = "Test2", Duration = "Test2", Difficulty = "Test", UserId = "1" });
                context.SaveChanges();

                WorkoutController workoutController = new WorkoutController(context);

                await workoutController.GetWorkout();


                Assert.NotEmpty(context.Workout);
                Assert.NotNull(context.Workout);

                Assert.Contains(context.Workout, w => w.Name == "Test1");
            }
        }

        [Fact]

        public async Task CheckIfWorkoutIsModifiedCorrectly()
        {
            using (var context = CreateInMemoryContext())
            {
                context.Add(new Workout { Id = 1, Name = "TestWorkout1", Description = "Test1", Duration = "Test1", Difficulty = "Test", UserId = "1" });
                context.Add(new Workout { Id = 2, Name = "TestWorkout2", Description = "Test2", Duration = "Test2", Difficulty = "Test", UserId = "1" });
                context.SaveChanges();

                WorkoutController workoutController = new WorkoutController(context);

                await workoutController.UpdateWorkout(2, "ModifiedWorkoutName", "ModifiedDescription", "ModifiedDuration", "ModifiedDifficulty", "1");

                Assert.Contains(context.Workout, w => w.Name == "ModifiedWorkoutName" && w.Id == 2);
            }
        }
    }
}
