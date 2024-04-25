using Fitsync.Models;
using Fitsync.Controllers;
using Fitsync.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;

namespace FitSync_Tests
{
    public class Exercise_Tests
    {
        private DatabaseContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Exercise")
                .Options;

            return new DatabaseContext(options);
        }

        [Fact]
        public async Task CheckIfDataIsCorrectlyReceived()
        {
            using (var context = CreateInMemoryContext())
            {
                context.Add(new Exercise() { Name = "TestExercise1", Difficulty = "Test", MuscleId = 1 });
                context.Add(new Exercise() { Name = "TestExercise2", Difficulty = "Test", MuscleId = 2 });
                context.SaveChanges();

                ExercisesController exercisesController = new ExercisesController(context);

                var actionResult = await exercisesController.GetExercise();
                var result = actionResult.Value as IEnumerable<Exercise>;

                Assert.NotNull(result);
                Assert.NotEmpty(result);

                var exercise1 = result.FirstOrDefault(e => e.Name == "TestExercise1");
                Assert.Equal("TestExercise1", exercise1.Name);
                Assert.Equal("Test", exercise1.Difficulty);
                Assert.Equal(1, exercise1.MuscleId);
            }
        }

        [Fact]
        public async Task CheckIfExerciseIsCreatedSuccessfully()
        {
            Exercise testExercise = new Exercise();
            testExercise.Name = "TestExercise2";
            testExercise.Difficulty = "Test";
            testExercise.MuscleId = 1;

            using (var context = CreateInMemoryContext())
            {
                context.Add(new Exercise() { Name = "TestExercise1", Difficulty = "Test", MuscleId = 1 });
                context.SaveChanges();

                ExercisesController exercisesController = new ExercisesController(context);
                await exercisesController.PostExercise(testExercise);

                var exercises = await context.Exercise.ToListAsync();

                Assert.Contains(exercises, e => e.Name == testExercise.Name);
            }
        }
    }
}